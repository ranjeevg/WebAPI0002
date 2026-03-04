namespace WebApi0002.Services;


/// <remarks>
/// DO NOT, I say DO NOT, use a static class as a dependency-injected service.
/// <br /><br />
/// <b>
/// EVER.
/// </b>
/// <br /><br />
/// Or else you get weird race conditions and the like.
/// <br /><br />
/// <i><b>
/// TL; DR: let DI do its job. Don't instantiate the class or otherwise play with instance lifetimes yourself,
/// let DI take care of that. That's what it's designed to do.
/// </b>
/// <br /><br />
/// (We aren't in the Ballmer era any longer, praise be.)
/// </i>
/// </remarks>
public class ActualWeatherAPICallsService
{
    
}