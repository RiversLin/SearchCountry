using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestCountryPortal.Models
{
    public class CountryDataModel
    {
        public CountryDataModel()
        {

        }

        public CountryDataModel(CountryDataModel item)
        {
            this.flag = item.flag;
            this.name = item.name;
            this.alpha2Code = item.alpha2Code;
            this.alpha3Code = item.alpha3Code;
            this.nativeName = item.nativeName;
            //this.altSpellings = item.altSpellings;
            this.altSpellingsCombination = string.Join(", ", item.altSpellings);
            //this.callingCodes = item.callingCodes;
            this.callingCodesCombination = string.Join(", ", item.callingCodes);

            // === Combine AlertContent ===

            // == currencies ==
            string currencies = string.Empty;
            foreach (var data in item.currencies)
            {
                currencies +=
                    @"code:" + data.code +
                    @"name:" + data.name +
                    @"symbol:" + data.symbol;
            }

            // == languages ==
            string languages = string.Empty;
            foreach (var data in item.languages)
            {
                languages +=
                    @"iso639_1:" + data.iso639_1 +
                    @"iso639_2:" + data.iso639_2 +
                    @"name:" + data.name +
                    @"nativeName:" + data.nativeName;
            }

            // == translations ==
            string translations = string.Empty;
            translations +=
                @"de:" + item.translations.de +
                @"es:" + item.translations.es +
                @"fr:" + item.translations.fr +
                @"ja:" + item.translations.ja +
                @"it:" + item.translations.it +
                @"br:" + item.translations.br +
                @"pt:" + item.translations.pt +
                @"nl:" + item.translations.nl +
                @"hr:" + item.translations.hr +
                @"fa:" + item.translations.fa;

            // == regionalBlocs ==
            string regionalBlocs = string.Empty;
            foreach (var data in item.regionalBlocs)
            {
                regionalBlocs +=
                    @"acronym:" + data.acronym +
                    @"name:" + data.name +
                    @"otherAcronyms:" + string.Join(", ", data.otherAcronyms) +
                    @"otherNames:" + string.Join(", ", data.otherNames);
            }

            this.alertContent =
                @"topLevelDomain:" + string.Join(", ", item.topLevelDomain) + "\\n" +
                @"capital:" + item.capital + "\\n" +
                @"region:" + item.region + "\\n" +
                @"subregion:" + item.subregion + "\\n" +
                @"population:" + item.population + "\\n" +
                @"latlng:" + string.Join(", ", item.latlng) + "\\n" +
                @"demonym: " + item.demonym + "\\n" +
                @"area:" + item.area + "\\n" +
                @"gini:" + item.gini + "\\n" +
                @"timezone:" + string.Join(", ", item.timezones) + "\\n" +
                @"borders:" + string.Join(", ", item.borders) + "\\n" +
                @"numericCode:" + item.numericCode + "\\n" +
                @"currencies:" + currencies + "\\n" +
                @"languages:" + languages + "\\n" +
                @"translations:" + translations + "\\n" +
                @"regionalBlocs:" + regionalBlocs + "\\n" +
                @"cioc:" + cioc;

            this.alertContent = "\""+ this.alertContent + "\"";
        }

        [JsonProperty(nameof(name))]
        public string name { get; set; }

        [JsonProperty(nameof(topLevelDomain))]
        public List<string> topLevelDomain { get; set; }

        [JsonProperty(nameof(alpha2Code))]
        public string alpha2Code { get; set; }

        [JsonProperty(nameof(alpha3Code))]
        public string alpha3Code { get; set; }

        [JsonProperty(nameof(callingCodes))]
        public List<string> callingCodes { get; set; }

        [JsonProperty(nameof(callingCodesCombination))]
        public string callingCodesCombination { get; set; }

        [JsonProperty(nameof(capital))]
        public string capital { get; set; }

        [JsonProperty(nameof(altSpellings))]
        public List<string> altSpellings { get; set; }

        [JsonProperty(nameof(altSpellingsCombination))]
        public string altSpellingsCombination { get; set; }

        [JsonProperty(nameof(region))]
        public string region { get; set; }

        [JsonProperty(nameof(subregion))]
        public string subregion { get; set; }

        [JsonProperty(nameof(population))]
        public int population { get; set; }

        [JsonProperty(nameof(latlng))]
        public List<double> latlng { get; set; }

        [JsonProperty(nameof(demonym))]
        public string demonym { get; set; }

        [JsonProperty(nameof(area))]
        public double? area { get; set; }

        [JsonProperty(nameof(gini))]
        public double? gini { get; set; }

        [JsonProperty(nameof(timezones))]
        public List<string> timezones { get; set; }

        [JsonProperty(nameof(borders))]
        public List<string> borders { get; set; }

        [JsonProperty(nameof(nativeName))]
        public string nativeName { get; set; }

        [JsonProperty(nameof(numericCode))]
        public string numericCode { get; set; }

        [JsonProperty(nameof(currencies))]
        public List<Currency> currencies { get; set; }

        [JsonProperty(nameof(languages))]
        public List<Language> languages { get; set; }

        [JsonProperty(nameof(translations))]
        public Translations translations { get; set; }

        [JsonProperty(nameof(flag))]
        public string flag { get; set; }

        [JsonProperty(nameof(regionalBlocs))]
        public List<RegionalBloc> regionalBlocs { get; set; }

        [JsonProperty(nameof(cioc))]
        public string cioc { get; set; }

        [JsonProperty(nameof(alertContent))]
        public string alertContent { get; set; }
    }

    public class Currency
    {

        [JsonProperty(nameof(code))]
        public string code { get; set; }

        [JsonProperty(nameof(name))]
        public string name { get; set; }

        [JsonProperty(nameof(symbol))]
        public string symbol { get; set; }
    }

    public class Language
    {

        [JsonProperty(nameof(iso639_1))]
        public string iso639_1 { get; set; }

        [JsonProperty(nameof(iso639_2))]
        public string iso639_2 { get; set; }

        [JsonProperty(nameof(name))]
        public string name { get; set; }

        [JsonProperty(nameof(nativeName))]
        public string nativeName { get; set; }
    }

    public class Translations
    {

        [JsonProperty(nameof(de))]
        public string de { get; set; }

        [JsonProperty(nameof(es))]
        public string es { get; set; }

        [JsonProperty(nameof(fr))]
        public string fr { get; set; }

        [JsonProperty(nameof(ja))]
        public string ja { get; set; }

        [JsonProperty(nameof(it))]
        public string it { get; set; }

        [JsonProperty(nameof(br))]
        public string br { get; set; }

        [JsonProperty(nameof(pt))]
        public string pt { get; set; }

        [JsonProperty(nameof(nl))]
        public string nl { get; set; }

        [JsonProperty(nameof(hr))]
        public string hr { get; set; }

        [JsonProperty(nameof(fa))]
        public string fa { get; set; }
    }

    public class RegionalBloc
    {

        [JsonProperty(nameof(acronym))]
        public string acronym { get; set; }

        [JsonProperty(nameof(name))]
        public string name { get; set; }

        [JsonProperty(nameof(otherAcronyms))]
        public List<string> otherAcronyms { get; set; }

        [JsonProperty(nameof(otherNames))]
        public List<string> otherNames { get; set; }
    }

}
