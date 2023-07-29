using CommonClasses;
using MatchingCampaignDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    internal class DonationRepository : IDonationRepository
    {
        MatchingContext context;
        public DonationRepository(MatchingContext context)
        {
            this.context = context;
        }

        public List<Donation> GetSpecific(string name)
        {
            try
            {
                List<Donation> l = new();
                var r = context.Donations.Include(d => d.Donor);
                foreach (var item in r)
                {
                    if (item.ThrowCollectorName.Equals(name))
                    {
                        l.Add(item);
                    }
                }
                //return r.Where(d => string.IsNullOrEmpty(d.ThrowCollectorName).Equals(name)).ToList();
                return l;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ooooooooops" + ex.Message);
                throw;
            }
        }

        public List<Donation> GetList()
        {
            try
            {
                return context.Donations.Include(d => d.Donor).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("ooooooooops");
                throw;
            }
        }

        public bool Post(FullDonationCommon fulldonationCommon)
        {
            try
            {
                Donation donation = new()
                {
                    CreditCard = new CreditCard()
                    {
                        CreditNumber = fulldonationCommon.CreditCard.CreditNumber,
                        Cvv = fulldonationCommon.CreditCard.Cvv,
                        Validity = fulldonationCommon.CreditCard.Validity,
                        Idnumber = fulldonationCommon.CreditCard.Idnumber,
                        Name = fulldonationCommon.CreditCard.Name,
                    },
                    Donor = new Donor()
                    {
                        DonorName = fulldonationCommon.DonorCommon.DonorName,
                        Adress = fulldonationCommon.DonorCommon.Adress,
                        Email = fulldonationCommon.DonorCommon.Email,
                        PhoneNumber = fulldonationCommon.DonorCommon.PhoneNumber,
                    },
                    Sum = fulldonationCommon.DonationCommon.Sum,
                    Date = DateTime.Now,
                    Inscription = fulldonationCommon.DonationCommon.Inscription,
                    ThrowCollectorName = fulldonationCommon.ThrowCollectorName,
                };
                if (fulldonationCommon.ThrowCollectorName != null)
                {
                    context.ManagersAndCollectors.FirstOrDefault(c => c.Name.Equals(fulldonationCommon.ThrowCollectorName)).CurrentSum += donation.Sum;
                }
                context.Matchings.FirstOrDefault().CurrentGoal += donation.Sum;
                context.Donations.AddAsync(donation);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ooooooooops" + " " + ex.Message);
                return false;
            }
        }

        public bool Put(int id, Donation t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}