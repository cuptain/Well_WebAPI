using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_V1336.Models;
using static WebApi_V1336.Models.WellCollection;

namespace WebApi_V1336.Controllers
{
    [RoutePrefix("api/wells")]
    public class WellsController : ApiController
    {
        // GET api/wells
        public IEnumerable<Well> GetWells()
        {
            return Wells;
        }

        // GET api/wells
        //public IEnumerable<Well> SearchWells(int id, int controllerId, Well.OperationTypeEnum operationType)
        //{
        //    if ((id.ToString() != null && id.ToString() != "") || (controllerId.ToString() != null
        //        && controllerId.ToString() != "") || (operationType != 0))
        //    {
        //        var select = from wells in Wells select wells;
        //        if (id.ToString() != null && id.ToString() != "")
        //        {
        //            select = from wells in @select
        //                     where wells.Id == id
        //                     select wells;
        //        }
        //        if (controllerId.ToString() != null && controllerId.ToString() != "")
        //        {
        //            select = from wells in @select
        //                     where wells.ControllerId == controllerId
        //                     select wells;
        //        }
        //        if (operationType != 0)
        //        {
        //            select = from wells in @select
        //                     where wells.OperationType == operationType
        //                     select wells;
        //        }
        //        List<Well> wellSearchResult = select.ToList();
        //        return wellSearchResult;
        //    }
        //    else
        //    {
        //        return Wells;
        //    }
        //}

        // GET api/wells/id

        
        public Well GetWell(int id)
        {
            return Wells.FirstOrDefault(w => w.Id == id);
        }

        // POST api/wells
        [HttpPost]
        public HttpResponseMessage CreateWell([FromBody]Well well)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Все поля должны быть заполнены");
            }
            try
            {
                int ID;
                if (Wells.Count == 0)
                    ID = 1;
                else
                    ID = Wells.Max(w => w.Id) + 1;
                well.Id = ID;
                Wells.Add(well);
                var message = Request.CreateResponse(HttpStatusCode.Created, well);
                message.Headers.Location = new Uri(Request.RequestUri + well.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/wells/id
        [HttpPut]
        public HttpResponseMessage EditWell(int id, [FromBody]Well newWell)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Все поля должны быть заполнены");
            }
            try
            {
                Well well = Wells.Find(w => w.Id == id);
                if (well == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Скважина с ID = " + id.ToString() + "не найдена");
                }
                else
                {
                    well.Name = newWell.Name;
                    well.Group = newWell.Group;
                    well.Field = newWell.Field;
                    well.Factory = newWell.Factory;
                    well.ControllerId = newWell.ControllerId;
                    well.OperationType = newWell.OperationType;

                    return Request.CreateResponse(HttpStatusCode.OK, well);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/wells/id     
        public HttpResponseMessage DeleteWell(int id)
        {
            try
            {
                Well well = Wells.Find(w => w.Id == id);
                if (well == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Скважина с ID = " + id.ToString() + "не найдена");
                }
                else
                {
                    Wells.Remove(well);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
