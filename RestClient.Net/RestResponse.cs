﻿namespace RestClientDotNet
{
    public class RestResponse<T> : RestResponse
    {
        public T Body { get; }

        public RestResponse(T body, IRestHeadersCollection restHeadersCollection, int statusCode, object underlyingResponse) : base(restHeadersCollection, statusCode, underlyingResponse)
        {
            Body = body;
        }

        #region Implicit Operator
#pragma warning disable CA2225 // Operator overloads have named alternates
        public static implicit operator T(RestResponse<T> readResult)
#pragma warning restore CA2225 // Operator overloads have named alternates
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            return readResult.Body;
#pragma warning restore CA1062 // Validate arguments of public methods
        }
        #endregion
    }

    public class RestResponse
    {
        #region Public Properties
        public int StatusCode { get; }
        public object UnderlyingResponse { get; }
        public IRestHeadersCollection Headers { get; }
        #endregion

        #region Constructor
        public RestResponse(IRestHeadersCollection restHeadersCollection, int statusCode, object underlyingResponse)
        {
            StatusCode = statusCode;
            UnderlyingResponse = underlyingResponse;
            Headers = restHeadersCollection;
        }
        #endregion


    }
}