using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Foods_CompShop.Data;
using Foods_CompShop.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Nancy.Json;
using System.Text;
using RestSharp;

namespace Foods_CompShop.Controllers
{
    public class CompShopsController : Controller
    {
        private readonly Foods_CompShopContext _context;


        private const string json = @"{""RuleApp"": { ""RepositoryRuleAppRevisionSpec"":{ ""RuleApplicationName"":""CompShop""}, ""UseIntegratedSecurity"":""false"",""UserName"":""amol_morankar29"",""Password"":""AkfGGjHj""},""RuleEngineServiceOptions"": {""Overrides"": """",""RuleEngineServiceOutputTypes"": {""ActiveNotifications"": ""true"",""ActiveValidations"": ""false"",""EntityState"": ""true"",""Overrides"": ""true"",RuleExecutionLog"": ""false""},""EntityName"": ""CompShopData"",""EntityState"":""{""State"":""WA""}""}";

        public CompShopsController(Foods_CompShopContext context)
        {            
            _context = context;            
        }

        //static async Task<string> GetResponseFromURI(Uri u)
        //{
        //    var response = "";
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage result = await client.GetAsync(u);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            response = await result.Content.ReadAsStringAsync();
        //        }
        //    }
        //    return response;
        //}

        public async Task GetBusinessRulesAsync()
        {
            string myJson = "{\"RuleApp\":{\"RepositoryRuleAppRevisionSpec\":{\"RuleApplicationName\":\"CompShop\"},\"UseIntegratedSecurity\":\"false\",\"UserName\":\"amol_morankar29\",\"Password\":\"AkfGGjHj\"},\"RuleEngineServiceOptions\":{\"Overrides\":\"\"},\"RuleEngineServiceOutputTypes\":{\"ActiveNotifications\":\"true\",\"ActiveValidations\":\"false\",\"EntityState\":\"true\",\"Overrides\":\"true\",\"RuleExecutionLog\":\"false\"},\"EntityName\":\"CompShopData\",\"EntityState\":\"{\\\"State\\\":\\\"WA\\\"}\"}";
            using (var client = new HttpClient())
            {

                var comps = new CompShop();
                comps.State = "WA";
                comps.CompShopId = 1;

                //var json1 = JsonConvert.SerializeObject(comps);
                var data = new StringContent(myJson, Encoding.UTF8, "application/json");

                var url = "https://trial-9fbyxg-986-execute.inrulecloud.com/HttpService.svc/ApplyRules";

                client.DefaultRequestHeaders.Add("Authorization", "APIKEY 3b77901f4c144b6cb87f9e6a8c1f68c5");

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;

                //client.DefaultRequestHeaders.Add("Authorization", "APIKEY 3b77901f4c144b6cb87f9e6a8c1f68c5");
                //client.BaseAddress = new Uri("https://trial-9fbyxg-986-execute.inrulecloud.com/HttpService.svc/ApplyRules");

                //var response = await client.PostAsync(
                //    "https://trial-9fbyxg-986-execute.inrulecloud.com/HttpService.svc/ApplyRules",
                //     new StringContent(json, Encoding.UTF8, "application/json"));
            }
            
            /*Uri baseUrl = new Uri("https://trial-9fbyxg-986-execute.inrulecloud.com/HttpService.svc/ApplyRules");
            IRestClient client = new RestClient(baseUrl);

            
            
            IRestRequest request = new RestRequest("post", Method.POST) { Credentials = new NetworkCredential("amol_morankar29", "AkfGGjHj") };
            request.AddHeader("Authorization", "APIKEY 3b77901f4c144b6cb87f9e6a8c1f68c5");
            //request.AddParameter("clientId", 123);

            IRestResponse<CompShop> response = client.Execute<CompShop>(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Data.StateMin);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }*/

            
        }

        // GET: CompShops
        public async Task<IActionResult> Index(string selectedDepot, string selectedDept, string selectedCategory, string selectedWarehouse, string selectedState, string selectedZip, string selectedDate, Boolean selectedResult, string genericSearch)
        {

           // await GetBusinessRulesAsync();

           
            var comps = from m in _context.CompShop
                        select m;


            IQueryable<string> depotQuery = from m in _context.CompShop
                                                orderby m.Dept, m.CompShopId ascending
                                                select m.Depot;

            IQueryable<string> warehouseQuery = from m in _context.CompShop
                                              orderby m.Dept, m.CompShopId ascending
                                              select m.WHSE;

            IQueryable<string> deptQuery = from n in _context.CompShop
                                          orderby n.Dept, n.Dept ascending
                                           select n.Dept;

            IQueryable<string> categoryQuery = from o in _context.CompShop
                                                 orderby o.Dept, o.Category ascending
                                               select o.Category;

            IQueryable<string> stateQuery = from p in _context.CompShop
                                             orderby p.Dept, p.State ascending
                                            select p.State;

            IQueryable<string> zipCodeQuery = from p in _context.CompShop
                                            orderby p.Dept, p.SamsShoppedZip
                                            select p.SamsShoppedZip;

            IQueryable<string> dateQuery = from p in _context.CompShop
                                              orderby p.Dept, p.FutureSellDate
                                              select p.FutureSellDate;

            if (!string.IsNullOrEmpty(selectedDepot))
            {
                comps = comps.Where(x => x.Depot == selectedDepot);
            }


            if (!string.IsNullOrEmpty(selectedWarehouse))
            {
                comps = comps.Where(x => x.WHSE == selectedWarehouse);
            }

            if (!string.IsNullOrEmpty(selectedDept))
            {
                comps = comps.Where(x => x.Dept == selectedDept);
            }

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                comps = comps.Where(x => x.Category == selectedCategory);
            }

            if (!string.IsNullOrEmpty(selectedState))
            {
                comps = comps.Where(x => x.State == selectedState);
            }


            if (!string.IsNullOrEmpty(selectedZip))
            {
                comps = comps.Where(x => x.State == selectedZip);
            }

            if (!string.IsNullOrEmpty(genericSearch))
            {
                comps = comps.Where(x => x.Description.Contains(genericSearch) || x.ItemNo.Contains(genericSearch));
            }


            if (selectedResult == true)
            {
                comps = comps.Where(x => Convert.ToDouble(x.LowestComp.Substring(1, x.LowestComp.Length - 1)) <= Convert.ToDouble(x.Sell.Substring(1, x.Sell.Length - 1)));
            }

            if (!string.IsNullOrEmpty(selectedDate))
            {
                comps = comps.Where(x => x.FutureSellDate == selectedDate);
            }

            var movieGenreVM = new SearchCompShop
            {
                DepotList = new SelectList(await depotQuery.Distinct().ToListAsync()),
                DeptList = new SelectList(await deptQuery.Distinct().ToListAsync()),
                CategoryList = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                WareHouseList = new SelectList(await warehouseQuery.Distinct().ToListAsync()),
                StateList = new SelectList(await stateQuery.Distinct().ToListAsync()),
                ZipCodeList = new SelectList(await zipCodeQuery.Distinct().ToListAsync()),
                DateList = new SelectList(await dateQuery.Distinct().ToListAsync()),


                compShop = await comps.ToListAsync()
            };
            //return View(await _context.CompShop.ToListAsync());
            return View(movieGenreVM);
        }

        // GET: CompShops/Details/5
        public IActionResult ManualComp()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var compShop = await _context.CompShop
            //    .FirstOrDefaultAsync(m => m.CompShopId == id);
            //if (compShop == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: CompShops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompShopId,Dept,ItemNo,Promo,WHSE,State,MAC,Sell,IMU,FutureSellPrice,FutureSellDate,LowestComp,MaxPrice,NewSell,NewPrice,SamsConvPrice,SamsShelfPrice,SamsAddtnPrice,SamsShoppedURL,SamsShoppedZip,BJsConvPrice,,BJsShelfPrice,BJsAddtnPrice,BJsShoppedURL,BJsShoppedZip,BuyerNo,Category,BuyerComments,PulledDate")] CompShop compShop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compShop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compShop);
        }

        // GET: CompShops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compShop = await _context.CompShop.FindAsync(id);
            if (compShop == null)
            {
                return NotFound();
            }
            return View(compShop);
        }

        // POST: CompShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompShopId,Dept,ItemNo,Promo,WHSE,State,MAC,Sell,IMU,FutureSellPrice,FutureSellDate,LowestComp,MaxPrice,NewSell,NewPrice,SamsConvPrice,SamsShelfPrice,SamsAddtnPrice,SamsShoppedURL,SamsShoppedZip,BJsConvPrice,,BJsShelfPrice,BJsAddtnPrice,BJsShoppedURL,BJsShoppedZip,BuyerNo,Category,BuyerComments,PulledDate")] CompShop compShop)
        {
            if (id != compShop.CompShopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compShop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompShopExists(compShop.CompShopId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(compShop);
        }

        // GET: CompShops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compShop = await _context.CompShop
                .FirstOrDefaultAsync(m => m.CompShopId == id);
            if (compShop == null)
            {
                return NotFound();
            }

            return View(compShop);
        }

        // POST: CompShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compShop = await _context.CompShop.FindAsync(id);
            _context.CompShop.Remove(compShop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompShopExists(int id)
        {
            return _context.CompShop.Any(e => e.CompShopId == id);
        }
    }
}
