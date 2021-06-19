using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using RestCountryPortal.Models;

namespace RestCountryPortal.Services
{
    public class SearchService
    {
        public SearchService()
        {

        }

        /// <summary>
        /// Get Country List
        /// </summary>
        /// <param name="nationName"></param>
        /// <param name="offsetTmp"></param>
        /// <param name="limitTmp"></param>
        /// <param name="sortDirTmp"></param>
        /// <returns></returns>
        public List<CountryDataModel> Search(string nationName, int offsetTmp, int limitTmp, string sortDirTmp)
        {
            try
            {
                // === Pagination ===
                int offset = 0, limit = 0;
                string sortDir = "";
                if (offsetTmp == 0)
                {
                    offset = 0;
                }
                else
                {
                    offset = offsetTmp;
                }
                if (limitTmp == 0)
                {
                    limit = 200;
                }
                else
                {
                    limit = limitTmp;
                }
               
                if (string.IsNullOrWhiteSpace(sortDirTmp))
                {
                    sortDir = "ASC";
                }
                else
                {
                    sortDir = sortDirTmp;
                }

                // === Get data ===

                List<CountryDataModel> countryItems = new List<CountryDataModel>();

                try
                {
                    string resultContent = this.GetRestCountry(nationName);

                    if (resultContent.Contains("Not Found"))
                    {
                        return null;
                    }
                    
                    countryItems = JsonConvert.DeserializeObject<List<CountryDataModel>>(resultContent);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                List<CountryDataModel> results = new List<CountryDataModel>();

                // === Return result ===
                foreach (var item in countryItems)
                {
                    results.Add(new CountryDataModel(item));
                }

                // === SortDir ===
                if (string.Compare("ASC", sortDir, true) == 0)
                {
                    results = results.OrderBy(x => x.name).ToList();
                }
                else if (string.Compare("DESC", sortDir, true) == 0)
                {
                    results = results.OrderByDescending(x => x.name).ToList();
                }

                // === Pagination ===
                results = results.Skip(offset).Take(limit).ToList();

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get data from RestCountry Api
        /// </summary>
        /// <param name="nationName"></param>
        /// <returns></returns>
        private string GetRestCountry(string nationName)
        {
            try
            {
                Uri uri = new Uri($"https://restcountries.eu/rest/v2/all");

                if(!string.IsNullOrWhiteSpace(nationName))
                    uri = new Uri($"https://restcountries.eu/rest/v2/name/{nationName}");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(uri);

                    var responseBody = response.Result.Content.ReadAsStringAsync();

                    if (responseBody != null)
                    {
                        return responseBody.Result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
