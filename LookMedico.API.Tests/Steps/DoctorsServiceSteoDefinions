using System.Net;
using System.Net.Mime;
using System.Text;
using LookMedico.API.ProfilesManagement.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace LookMedico.API.Tests;

[Binding]
public class DoctorsServiceStepDefinitions: WebApplicationFactory<Program>
{
     private readonly WebApplicationFactory<Program> _factory;


     public DoctorsServiceStepDefinitions(WebApplicationFactory<Program> factory)
     {
         _factory = factory;
     }
     
     private HttpClient Client { get; set; }
    
     private Uri BaseUri { get; set; }
    
     private Task<HttpResponseMessage> Response { get; set; }

     [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/doctors is available")]
    public void GivenTheEndpointHttpsLocalhostApiVDoctorsIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/doctors");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }


    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveDoctorResource)
    {
         var resource = saveDoctorResource.CreateSet<SaveDoctorResource>().First();
                var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
                Response = Client.PostAsync(BaseUri, content);
    }


    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
                var actualStatusCode = Response.Result.StatusCode.ToString();
                
                Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Doctor Resource is included in Response Body")]
    public async void ThenADoctorResourceIsIncludedInResponseBody(Table expectedDoctorResource)
    {
        var expectedResource = expectedDoctorResource.CreateSet<DoctorResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<DoctorResource>(responseData);
        
        Assert.Equal(expectedResource.Id, resource.Id);
    }

    [Given(@"A Doctor is already stored")]
    public async void GivenADoctorIsAlreadyStored(Table saveDoctorResource)
    {
        var resource = saveDoctorResource.CreateSet<SaveDoctorResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var responseResource = new DoctorResource();
        try
        {
            responseResource = JsonConvert.DeserializeObject<DoctorResource>(responseData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Assert.Equal(resource.Id, responseResource.Id);
        //
    }

    [Then(@"An Error Message is returned with value ""(.*)""")]
    public void ThenAnErrorMessageIsReturnedWithValue(string expectedMessage)
    {
        var actualMessage = Response.Result.Content.ReadAsStringAsync().Result;
        
        Assert.Equal(expectedMessage, actualMessage);
    }
}using System.Net;
using System.Net.Mime;
using System.Text;
using LookMedico.API.ProfilesManagement.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace LookMedico.API.Tests;

[Binding]
public class DoctorsServiceStepDefinitions: WebApplicationFactory<Program>
{
     private readonly WebApplicationFactory<Program> _factory;


     public DoctorsServiceStepDefinitions(WebApplicationFactory<Program> factory)
     {
         _factory = factory;
     }
     
     private HttpClient Client { get; set; }
    
     private Uri BaseUri { get; set; }
    
     private Task<HttpResponseMessage> Response { get; set; }

     [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/doctors is available")]
    public void GivenTheEndpointHttpsLocalhostApiVDoctorsIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/doctors");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }


    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveDoctorResource)
    {
         var resource = saveDoctorResource.CreateSet<SaveDoctorResource>().First();
                var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
                Response = Client.PostAsync(BaseUri, content);
    }


    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
                var actualStatusCode = Response.Result.StatusCode.ToString();
                
                Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Doctor Resource is included in Response Body")]
    public async void ThenADoctorResourceIsIncludedInResponseBody(Table expectedDoctorResource)
    {
        var expectedResource = expectedDoctorResource.CreateSet<DoctorResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<DoctorResource>(responseData);
        
        Assert.Equal(expectedResource.Id, resource.Id);
    }

    [Given(@"A Doctor is already stored")]
    public async void GivenADoctorIsAlreadyStored(Table saveDoctorResource)
    {
        var resource = saveDoctorResource.CreateSet<SaveDoctorResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var responseResource = new DoctorResource();
        try
        {
            responseResource = JsonConvert.DeserializeObject<DoctorResource>(responseData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Assert.Equal(resource.Id, responseResource.Id);
        //
    }

    [Then(@"An Error Message is returned with value ""(.*)""")]
    public void ThenAnErrorMessageIsReturnedWithValue(string expectedMessage)
    {
        var actualMessage = Response.Result.Content.ReadAsStringAsync().Result;
        
        Assert.Equal(expectedMessage, actualMessage);
    }
}
