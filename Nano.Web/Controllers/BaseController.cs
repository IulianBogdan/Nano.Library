using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.Eventing.Interfaces;
using Nano.Services.Interfaces;
using Nano.Web.Hosting;

namespace Nano.Web.Controllers
{
    // TODO: Api-Clubs generate (NSwag, Google or similar) 

    /// <summary>
    /// Base controller.
    /// </summary>
    [Route("[controller]")]
    [Authorize(Roles = "administrator, service")]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Options. Any route can be called with http options, to return options header information.
        /// </summary>
        /// <returns>Void.</returns>
        /// <response code="200">Success.</response>
        /// <response code="401">Unauthorized.</response>
        [HttpOptions]
        [Route("")]
        [Produces(HttpContentType.JSON, HttpContentType.XML, HttpContentType.HTML)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public virtual IActionResult Options()
        {
            return this.Ok("OK");
        }
    }

    /// <summary>
    /// Base generic controller.
    /// </summary>
    /// <typeparam name="TService">The <see cref="IService"/>.</typeparam>
    public abstract class BaseController<TService> : BaseController
       where TService : IService
    {
        /// <summary>
        /// Logger.
        /// </summary>
        protected virtual ILogger Logger { get; }

        /// <summary>
        /// Service.
        /// </summary>
        protected virtual TService Service { get; }

        /// <summary>
        /// Eventing.
        /// </summary>
        protected virtual IEventing Eventing { get; }

        /// <summary>
        /// Constructor accepting an instance of <typeparamref name="TService"/> and initializing <see cref="Service"/>
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="service">The <see cref="IService"/>.</param>
        /// <param name="eventing">The <see cref="IEventingProvider"/>.</param>
        protected BaseController(ILogger logger, TService service, IEventing eventing)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (service == null)
                throw new ArgumentNullException(nameof(service));

            if (eventing == null)
                throw new ArgumentNullException(nameof(eventing));

            this.Logger = logger;
            this.Service = service;
            this.Eventing = eventing;
        }
    }
}