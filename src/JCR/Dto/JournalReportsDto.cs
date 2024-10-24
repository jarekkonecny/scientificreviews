using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.JCR.Dto
{
    public class JournalReportsDto
    {
        public int Year { get; set; }
        public bool Suppressed { get; set; }
        public JournalDto Journal { get; set; }
        public MetricsDto Metrics { get; set; }
        public RanksDto Ranks { get; set; }
        public JournalDataDto JournalData { get; set; }
        public SourceDataDto SourceData { get; set; }
        public JournalProfileDto JournalProfile { get; set; }
    }

    public class JournalDto
    {
        public string Id { get; set; }
        public string Self { get; set; }
        public string Name { get; set; }
    }

    public class MetricsDto
    {
        public ImpactMetricsDto ImpactMetrics { get; set; }
        public InfluenceMetricsDto InfluenceMetrics { get; set; }
        public SourceMetricsDto SourceMetrics { get; set; }
        public CitationDistributionDto CitationDistribution { get; set; }
    }

    public class ImpactMetricsDto
    {
        public int TotalCites { get; set; }
        public string Jif { get; set; }
        public string JifWithoutSelfCitations { get; set; }
        public double Jif5Years { get; set; }
        public double ImmediacyIndex { get; set; }
        public double Jci { get; set; }
    }

    public class InfluenceMetricsDto
    {
        public EigenFactorDto EigenFactor { get; set; }
        public double ArticleInfluence { get; set; }
    }

    public class EigenFactorDto
    {
        public double Score { get; set; }
        public double Normalized { get; set; }
    }

    public class SourceMetricsDto
    {
        public CitableItemsDto CitableItems { get; set; }
        public double JifPercentile { get; set; }
        public HalfLifeDto HalfLife { get; set; }
    }

    public class CitableItemsDto
    {
        public int Total { get; set; }
        public double ArticlesPercentage { get; set; }
    }

    public class HalfLifeDto
    {
        public double Cited { get; set; }
        public double Citing { get; set; }
    }

    public class CitationDistributionDto
    {
        public double ArticleCitationMedian { get; set; }
        public double ReviewCitationMedian { get; set; }
        public double UnlinkedCitations { get; set; }
        public double TimesCited { get; set; }
        public double Articles { get; set; }
        public double Reviews { get; set; }
        public double Other { get; set; }
    }

    public class RanksDto
    {
        public List<JifRankDetailDto> Jif { get; set; }
        public List<RankDetailDto> ArticleInfluence { get; set; }
        public List<RankDetailDto> EigenFactorScore { get; set; }
        public List<RankDetailDto> ImmediacyIndex { get; set; }
        public List<JciRankDetailDto> Jci { get; set; }
        public List<EsiRankDetailDto> EsiCitations { get; set; }
    }

    public class RankDetailDto
    {
        public string Category { get; set; }
        public string Edition { get; set; }
        public string Self { get; set; }
        public string Rank { get; set; }
        public string Quartile { get; set; }
    }

    public class EsiRankDetailDto
    {
        public string Category { get; set; }
        public string Rank { get; set; }
        public string Quartile { get; set; }
    }

    public class JifRankDetailDto
    {
        public string Category { get; set; }
        public string Edition { get; set; }
        public string Self { get; set; }
        public string Rank { get; set; }
        public string Quartile { get; set; }
        public double JifPercentile { get; set; }
    }

    public class JciRankDetailDto
    {
        public string Category { get; set; }
        public string Rank { get; set; }
        public string Quartile { get; set; }
        public double JciPercentile { get; set; }
    }

    public class JournalDataDto
    {
        public CitedCitingDto Cited { get; set; }
        public CitedCitingDto Citing { get; set; }
    }

    public class CitedCitingDto
    {
        public string Url { get; set; }
        public int Count { get; set; }
    }

    public class SourceDataDto
    {
        public DataCountReferencesDto Articles { get; set; }
        public DataCountReferencesDto Reviews { get; set; }
        public DataCountReferencesDto Other { get; set; }
    }

    public class DataCountReferencesDto
    {
        public int Count { get; set; }
        public int References { get; set; }
    }

    public class JournalProfileDto
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public CitableItemsProfileDto CitableItems { get; set; }
        public CitationsProfileDto Citations { get; set; }
        public List<OccurrenceCountryDto> OccurrenceCountries { get; set; }
        public List<OccurrenceOrganizationDto> OccurrenceOrganizations { get; set; }
    }

    public class CitableItemsProfileDto
    {
        public int GoldOA { get; set; }
        public int Subscription { get; set; }
        public int Other { get; set; }
    }

    public class CitationsProfileDto
    {
        public int GoldOA { get; set; }
        public int Subscription { get; set; }
        public int Other { get; set; }
        public int Unlinked { get; set; }
    }

    public class OccurrenceCountryDto
    {
        public string CountryRegion { get; set; }
        public int Occurrence { get; set; }
    }

    public class OccurrenceOrganizationDto
    {
        public string Organization { get; set; }
        public int Occurrence { get; set; }
    }
}
