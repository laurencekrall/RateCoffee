using Google.Cloud.Vision.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateCoffee.GoogleApi
{
    public class GoogleApiService
    {
        InstantiatedImageAnnotatorClient _client;

        public GoogleApiService(InstantiatedImageAnnotatorClient client)
        {
            _client = client;
        }
        public string GetSimilar()
        {
            var client = InstantiatedImageAnnotatorClient.GetClient();
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");

            Image image = Image.FromFile($"{path}\\maddoggy.jpg");
            var opts = new GetSimilarProductsOptions()
            {
                ComputeRegion = "europe-west1",
                ProjectID = "ninth-terminal-245420",
                ProductSetId = "1",
                Filter = "",
                ProductCategory = "packagedgoods-v1",
            };

            var productSearchParams = new ProductSearchParams
            {
                ProductSetAsProductSetName = new ProductSetName(opts.ProjectID,
                                                               opts.ComputeRegion,
                                                               opts.ProductSetId),
                ProductCategories = { opts.ProductCategory },
                Filter = opts.Filter
            };

            // Search products similar to the image.
            var results = client.DetectSimilarProducts(image, productSearchParams);

            return JsonConvert.SerializeObject(results);
        }
    }


}
