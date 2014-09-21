﻿using System.Net;
using RestSharp;

namespace InfluxDB.Net.Core
{
    public class InfluxDbResponse
    {
        public IRestResponse Raw { get; private set; }

        public virtual bool Success
        {
            get { return Raw.StatusCode == HttpStatusCode.OK; }
        }

        public InfluxDbResponse(IRestResponse response)
        {
            Raw = response;
        }
    }

    public class CreateDbResponse : InfluxDbResponse
    {
        public CreateDbResponse(IRestResponse response)
            : base(response)
        {
        }

        public override bool Success
        {
            get { return Raw.StatusCode == HttpStatusCode.Created; }
        }
    }
    public class DeleteDbResponse : InfluxDbResponse
    {
        public DeleteDbResponse(IRestResponse response)
            : base(response)
        {
        }

        public override bool Success
        {
            //TODO: Ask to influx db creators
            get { return Raw.StatusCode == HttpStatusCode.NoContent; }
        }
    }
}