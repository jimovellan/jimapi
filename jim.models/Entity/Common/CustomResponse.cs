using System;
using System.Collections.Generic;
using System.Text;

namespace jim.models.Entity.Common
{   
    /// <summary>
    /// This class is used to Response by all controllers,
    /// contains a List of errors about the executed operation,
    /// And a property  to evaluate the operation result
    /// </summary>
    public class CustomResponse
    {
        public bool Success { get; private set; }

        public IList<string> Errors { get; private set; }

        protected CustomResponse()
        {
            Errors = new List<string>();
            Success = true;
        }
        
        public void AddError(string error)
        {
            if(Errors == null)
            {
                Errors = new List<string>();
            }
            Errors.Add(error);
            Success = false;
        }

        public void AddError(IList<string> errors)
        {
            foreach (var error in errors)
            {
                AddError(error);
            }
        }

        public static CustomResponse Fail(IList<string> errors)
        {
            var response = new CustomResponse();
            response.AddError(errors);
            return response;
        }

        public static CustomResponse<Tentity> Fail<Tentity>(string error)
        {
            var response = new CustomResponse<Tentity>(error);
            return response;
        }

        public static CustomResponse<Tentity> Fail<Tentity>(IList<string> errors)
        {
            var response = new CustomResponse<Tentity>(errors);
            return response;
        }

        public static CustomResponse Fail(string error)
        {
            var response = new CustomResponse();
            response.AddError(error);
            return response;
        }

        public static CustomResponse Ok()
        {
            return new CustomResponse();
        }

        public static CustomResponse<T> Ok<T>(T entity)
        {
            return new CustomResponse<T>(entity);
        }


    }


    public class CustomResponse<T>:CustomResponse 
    {
        public T Value { get; private set; }

        internal CustomResponse(T entity) : base()
        {
            Value = entity;
            
        }

        internal CustomResponse(IList<string> errors):base()
        {
            AddError(errors);
        }

        internal CustomResponse(string error) : base()
        {
            AddError(error);
        }

    }
}
