﻿using System.Linq;
using Omu.ValueInjecter;
using coreModel = VirtoCommerce.Domain.Catalog.Model;
using webModel = VirtoCommerce.CatalogModule.Web.Model;

namespace VirtoCommerce.CatalogModule.Web.Converters
{
    public static class AggregationConverters
    {
        public static webModel.Aggregation ToWebModel(this coreModel.Aggregation aggregation)
        {
            var result = new webModel.Aggregation();
            result.AggregationType = aggregation.AggregationType;
            result.Field = aggregation.Field;          

            if (aggregation.Items != null)
            {
                result.Items = aggregation.Items.Select(i => i.ToWebModel()).ToArray();
            }

            if (aggregation.Labels != null)
            {
                result.Labels = aggregation.Labels.Select(ToWebModel).ToArray();
            }

            return result;
        }

        public static webModel.AggregationItem ToWebModel(this coreModel.AggregationItem item)
        {
            var result = new webModel.AggregationItem();
            result.Count = item.Count;
            result.IsApplied = item.IsApplied;
            result.Value = item.Value;

            if (item.Labels != null)
            {
                result.Labels = item.Labels.Select(ToWebModel).ToArray();
            }

            return result;
        }

        public static webModel.AggregationLabel ToWebModel(this coreModel.AggregationLabel label)
        {
            return new webModel.AggregationLabel
            {
                Language = label.Language,
                Label = label.Label,
            };
        }
    }
}
