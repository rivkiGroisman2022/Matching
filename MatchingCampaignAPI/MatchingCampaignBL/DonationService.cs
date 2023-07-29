using CommonClasses;
using MatchingCampaignDAL;

namespace MatchingCampaignBL
{
    public class DonationService : IDonationService
    {
        IDonationRepository donationRepository;
        public DonationService(IDonationRepository donationRepository)
        {
            this.donationRepository = donationRepository;
        }

        public List<DonationCommon> Get()
        {
            var result = donationRepository.GetList();
            return result.Select(donation => new DonationCommon()
            {
                DonorName = donation.Donor.DonorName,
                Date = donation.Date,
                Sum = donation.Sum,
                Inscription = donation.Inscription
            }
            ).ToList();
        }

        public List<DonationCommon> GetSpecific(string name)
        {
            var result = donationRepository.GetSpecific(name);
            return result.Select(donation => new DonationCommon()
            {
                DonorName = donation.Donor.DonorName,
                Date = donation.Date,
                Sum = donation.Sum,
                Inscription = donation.Inscription
            }
            ).ToList();
        }

        public bool Post(FullDonationCommon fulldonationCommon)
        {
            var result = donationRepository.Post(fulldonationCommon);
            return result;
        }
    }
}