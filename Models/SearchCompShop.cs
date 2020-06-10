using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Foods_CompShop.Models
{
    public class SearchCompShop
    {
        public List<CompShop> compShop { get; set; }

        [NotMapped]
        public SelectList DepotList { get; set; }

        [NotMapped]
        public SelectList DeptList { get; set; }

        [NotMapped]
        public SelectList CategoryList { get; set; }

        [NotMapped]
        public SelectList WareHouseList { get; set; }

        [NotMapped]
        public SelectList StateList { get; set; }

        [NotMapped]
        public SelectList ZipCodeList { get; set; }


        [NotMapped]
        public SelectList DateList { get; set; }

        //[Display(Name = "Future Date")]
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SelectedFutureDate { get; set; } =  DateTime.Now;



        public string SelectedDepot { get; set; }
        public string SelectedDept { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedWarehouse { get; set; }
        public string SelectedState { get; set; }

        public string SelectedZipCode { get; set; }

        public string SelectedDate { get; set; }

        public Boolean SelectedResult { get; set; }
    }
}
