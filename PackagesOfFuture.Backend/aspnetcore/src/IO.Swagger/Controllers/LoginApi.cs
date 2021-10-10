/*
 * PackagesOfFuture.Api
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LoginApiController : ControllerBase
    { 
        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="body">Representation of login details</param>
        /// <response code="200">When user was logged in</response>
        /// <response code="400">When no user with selected email and password exists</response>
        [HttpPost]
        [Route("/Login")]
        [ValidateModelState]
        [SwaggerOperation("LoginPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(LogInResponseResponse), description: "When user was logged in")]
        public virtual IActionResult LoginPost([FromBody]LogInDto body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(LogInResponseResponse));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            string exampleJson = null;
            exampleJson = "{\n  \"error\" : \"error\",\n  \"content\" : {\n    \"firstName\" : \"firstName\",\n    \"lastName\" : \"lastName\",\n    \"address\" : {\n      \"houseAndFlatNumber\" : \"houseAndFlatNumber\",\n      \"city\" : \"city\",\n      \"street\" : \"street\",\n      \"postalCode\" : \"postalCode\"\n    },\n    \"id\" : 0,\n    \"userName\" : \"userName\",\n    \"type\" : 6,\n    \"email\" : \"email\"\n  },\n  \"succeeded\" : true\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<LogInResponseResponse>(exampleJson)
                        : default(LogInResponseResponse);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
