using System;
using System.Collections.Generic;
using GameOfWhales.Json;
using UnityEngine;
using UnityEngine.Purchasing;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace GameOfWhales
{
    public class SpecialOffers
    {
        public class Definition
        {
            public readonly string id;
            public readonly string title;
            public readonly string description;
            public readonly Dictionary<string, string> skus;

            public readonly DateTime activatedAt;
            public readonly DateTime dateTo;
            public readonly float activation;
            public readonly DateTime finishAt;

            public readonly string soPayload;

            public Definition(JsonObject json)
            {
                if (!json.TryGet("_id", out id))
                    throw new UnityException("Wrong id");
                json.TryGet("title", out title);
                json.TryGet("description", out description);
                json.TryGet("activation", out activation);
                json.TryGet("soPayload", out soPayload);

                long activatedAtLong;
                if (json.TryGet("activatedAt", out activatedAtLong)) {
                    activatedAt = FromUnixTime(activatedAtLong);
                } else {
                    activatedAt = DateTime.UtcNow;
                }

                long dateToLong;
                if (json.TryGet("dateTo", out dateToLong)) {
                    dateTo = FromUnixTime(dateToLong);
                }

                JsonObject skusJson;
                if (json.TryGet("skus", out skusJson)) {
                    skus = skusJson.ToDictionary(p => p.Key, p => Convert.ToString(p.Value));
                } else {
                    skus = new Dictionary<string, string>();
                }

                var finishActivation = activatedAt.AddHours(activation);
                finishAt = dateTo > finishActivation ? finishActivation : dateTo;
            }

            private DateTime FromUnixTime(long unixTime)
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return epoch.AddMilliseconds(unixTime);
            }

            public IEnumerable<string> GetIds()
            {
                foreach (var pair in skus)
                {
                    yield return pair.Key;
                    yield return pair.Value;
                }
            }

            public bool IsExpired()
            {
                return DateTime.UtcNow > dateTo || DateTime.UtcNow > activatedAt.AddHours(activation);
            }

            public bool IsActive()
            {
                return skus != null && !IsExpired();
            }
        }

        public class Replacement
        {
            public readonly Definition definition;
            public readonly string sku;
            public readonly Product product;
            public readonly float price;
            public readonly string originalSku;
            public readonly Product originalProduct;
            public readonly float originalPrice;

            public Replacement(IStoreController store, Definition definition, string originalSku, string sku)
            {
                this.definition = definition;
                this.originalSku = originalSku;
                this.sku = sku;

                originalProduct = store.products.WithID(originalSku);
                if (originalProduct == null)
                {
                    Debug.LogError("Product '" + originalSku + "' not found in store");
                }
                else
                {
                    originalPrice = (float) originalProduct.metadata.localizedPrice;
                }
                product = store.products.WithID(sku);
                if (product == null)
                {
                    Debug.LogError("Product '" + sku + "' not found in store");
                }
                else
                {
                    price = (float) product.metadata.localizedPrice;
                }
            }
        }

        private readonly List<Definition> _sos = new List<Definition>();
        private readonly Dictionary<string, Replacement> _best = new Dictionary<string, Replacement>();

        private readonly Dictionary<string, List<Replacement>> _replacements =
            new Dictionary<string, List<Replacement>>();

        public void Clear()
        {
            _sos.Clear();
        }

        public void Add(Definition so)
        {
            var oldSO = _sos.FirstOrDefault(d => d.id == so.id);

            if (oldSO != null)
            {
                _sos.Remove(oldSO);
            }

            _sos.Add(so);
        }

        public IEnumerable<Definition> GetDefinitions()
        {
            return _sos;
        }

        public IEnumerable<string> GetSkus()
        {
            foreach (var so in _sos)
            {
                if (!so.IsActive()) continue;
                foreach (var pair in so.skus)
                {
                    yield return pair.Key;
                    yield return pair.Value;
                }
            }
        }

        public void Init(IStoreController store)
        {
            var reps = new List<Replacement>();
            foreach (var so in _sos)
            {
                if (!so.IsActive()) continue;
                foreach (var pair in so.skus)
                {
                    reps.Add(new Replacement(store, so, pair.Key, pair.Value));
                }
            }
            _replacements.Clear();
            _best.Clear();
            reps.Where(r => r.product != null)
                .ForEach(r =>
                {
                    Replacement current;
                    if (!_best.TryGetValue(r.originalSku, out current)
                        || current.price > r.price)
                    {
                        _best[r.originalSku] = r;
                    }

                    List<Replacement> list;
                    if (!_replacements.TryGetValue(r.originalSku, out list))
                    {
                        list = new List<Replacement>();
                        _replacements[r.originalSku] = list;
                    }
                    list.Add(r);
                });
        }

        public DateTime Check(IStoreController store, Action<Definition> onRemove)
        {
            var index = 0;
            var removeCount = 0;
            var waitTo = DateTime.UtcNow.AddSeconds(60);
            while (index < _sos.Count)
            {
                var so = _sos[index];
                if (so.IsActive())
                {
                    index++;
                    if (waitTo > so.finishAt)
                    {
                        waitTo = so.finishAt;
                    }
                }
                else
                {
                    _sos.RemoveAt(index);
                    if (onRemove != null)
                    {
                        onRemove(so);
                    }
                    removeCount++;
                }
            }

            if (removeCount > 0)
            {
                Init(store);
            }
            return waitTo;
        }

        public Replacement GetReplacement(string sku)
        {
            Replacement rep;
            if (_best.TryGetValue(sku, out rep))
            {
                return rep;
            }
            return null;
        }

        public IEnumerable<Replacement> GetReplacements(string sku)
        {
            List<Replacement> list;
            if (_replacements.TryGetValue(sku, out list))
            {
                return list;
            }
            return new Replacement[0];
        }

        public IEnumerable<Replacement> GetAllReplacements() {
            List<Replacement> list = new List<Replacement>();
            _replacements.ForEach(kvp => {
                list.AddRange(kvp.Value);
            });
            return list.ToArray();
        }

        public Replacement GetReplacementBySOSku(string soSku)
        {
            return _best.Select(kvp => kvp.Value).FirstOrDefault(r => r.sku == soSku);
        }
    }
}