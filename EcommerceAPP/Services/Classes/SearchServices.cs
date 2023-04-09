using EcommerceAPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace EcommerceAPP.Services.Classes
{
    public static class SearchServices
    {
        public static ObservableCollection<OrderProduct> SearchInOrders(string searchText, ObservableCollection<OrderProduct> searchResults, ObservableCollection<OrderProduct> basketProducts)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                searchResults = new(basketProducts);
                return searchResults;
            }

            var results = basketProducts.Where(i => i.Product!.Name == searchText);

            searchResults.Clear();
            foreach (var result in results)
            {
                searchResults.Add(result);
            }
            return searchResults;
        }
    }
}
