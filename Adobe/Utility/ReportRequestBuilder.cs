namespace Adobe.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Models.Analytics;
    using Models.General;
    using Models.Ranked;
    using Models.Report;
    using Models.Report.Enums;

    public class ReportRequestBuilder
    {
        private ReportFilter _dateRangeFilter;

        private readonly List<ReportMetric> _metrics;

        private readonly List<ReportFilter> _metricFilters;

        private readonly List<ReportFilter> _reportFilters;

        private string Rsid { get; set; }

        private string Dimension { get; set; }

        private Locale Locale { get; set; }

        public RankedSettings Settings { get; set; }

        public ReportRequestBuilder()
        {
            _metrics = new List<ReportMetric>();
            _metricFilters = new List<ReportFilter>();
            _reportFilters = new List<ReportFilter>();
        }

        public ReportRequestBuilder WithReportSuiteId(string id)
        {
            Rsid = id;
            return this;
        }

        public ReportRequestBuilder WithFilter(ReportFilter filter)
        {
            _reportFilters.Add(filter);
            return this;
        }

        public ReportRequestBuilder WithDateRange(DateTime from, DateTime to)
        {
            _dateRangeFilter = new ReportFilter
            {
                Type = ReportFilterType.DATE_RANGE,
                DateRange = $"{FormatDateTime(from)}/{FormatDateTime(to)}"
            };

            return this;
        }

        public ReportRequestBuilder WithDimension(AnalyticsDimension dimension)
        {
            Dimension = dimension.Id;
            return this;
        }

        public ReportRequestBuilder WithMetric(AnalyticsMetric metric)
        {
            var reportMetric = new ReportMetric
            {
                Id = metric.Id,
                ColumnId = metric.Id
            };

            _metrics.Add(reportMetric);
            return this;
        }

        public ReportRequestBuilder WithMetrics(IEnumerable<AnalyticsMetric> metrics)
        {
            foreach (var metric in metrics)
            {
                WithMetric(metric);
            }

            return this;
        }

        public ReportRequestBuilder WithMetrics(params AnalyticsMetric[] metrics) => WithMetrics(metrics.AsEnumerable());

        public ReportRequestBuilder WithLocale(Locale locale)
        {
            Locale = locale;
            return this;
        }

        public ReportRequestBuilder WithSettings(RankedSettings settings)
        {
            Settings = settings;
            return this;
        }

        public RankedRequest Build()
        {
            var reportRequest = new RankedRequest
            {
                Rsid = Rsid,
                Dimension = Dimension,
                Locale = Locale,
                Settings = Settings,
                MetricContainer = new ReportMetrics
                {
                    Metrics = _metrics,
                    MetricFilters = _metricFilters
                },
                GlobalFilters = _reportFilters
            };

            reportRequest.GlobalFilters.Add(_dateRangeFilter);
            return reportRequest;
        }

        private static string FormatDateTime(DateTime date) => date.ToString("yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
    }
}