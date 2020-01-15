using System.ComponentModel.DataAnnotations;

namespace TubeRehber.Service.TransferObjects.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
