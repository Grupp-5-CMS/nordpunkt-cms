
using System.ComponentModel.DataAnnotations;

namespace nordpunkt_cms.ViewModels
{
    public class NewsTipFormViewModel
    {
        [Required(ErrorMessage = "Ange en rubrik för nyhetstipset.")]
        [Display(Name = "Rubrik på nyhetstipset")]
        public string TipHeadline { get; set; } = string.Empty;

        [Required(ErrorMessage = "Beskriv nyhetstipset.")]
        [Display(Name = "Beskrivning av nyhetstipset")]
        public string TipBody { get; set; } = string.Empty;

        [Display(Name = "Namn")]
        public string? SenderName { get; set; }

        [EmailAddress(ErrorMessage = "Ange en giltig e-postadress.")]
        [Display(Name = "E-post")]
        public string? SenderEmail { get; set; }

        [Display(Name = "Telefonnummer")]
        public string? SenderPhone { get; set; }

        [Range(typeof(bool), "true", "true",
            ErrorMessage = "Du måste godkänna personuppgiftshanteringen.")]
        [Display(Name = "Jag godkänner informationen om personuppgiftshantering")]
        public bool PrivacyConsent { get; set; }
    }
}
