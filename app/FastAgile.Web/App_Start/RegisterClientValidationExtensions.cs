using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(FastAgile.Web.App_Start.RegisterClientValidationExtensions), "Start", callAfterGlobalAppStart: true)]
 
namespace FastAgile.Web.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}