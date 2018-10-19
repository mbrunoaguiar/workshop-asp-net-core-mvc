using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || _context.SalesRecord.Any() || _context.Seller.Any())
            {
                return; // DB já está alimentado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob", "bob@gmail.com", new DateTime(1988, 4, 25), 1000, d1);
            Seller s2 = new Seller(2, "Bruno", "bruno@gmail.com", new DateTime(1986, 8, 15), 1000, d2);
            Seller s3 = new Seller(3, "Izabela", "bela@gmail.com", new DateTime(1986, 6, 22), 1000, d3);
            Seller s4 = new Seller(4, "Izadora", "dora@gmail.com", new DateTime(1990, 8, 21), 1000, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 10, 12), 9670, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 10, 12), 3320, SaleStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 10, 12), 4400, SaleStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018, 10, 14), 2353, SaleStatus.Billed, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2018, 10, 14), 2130, SaleStatus.Billed, s4);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2018, 10, 14), 2330, SaleStatus.Billed, s2);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2018, 10, 17), 3230, SaleStatus.Billed, s1);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2018, 10, 17), 4560, SaleStatus.Billed, s3);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2018, 10, 18), 2300, SaleStatus.Billed, s3);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1,s2,s3,s4);
            _context.SalesRecord.AddRange(sr1,sr2,sr3,sr4,sr5,sr6,sr7,sr8,sr9);
            _context.SaveChanges();
        }
    }
}
