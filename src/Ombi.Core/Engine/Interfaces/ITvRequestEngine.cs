﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ombi.Core.Models.Search;
using Ombi.Store.Entities.Requests;

namespace Ombi.Core.Engine.Interfaces
{
    public interface ITvRequestEngine : IRequestEngine<TvRequests>
    {

        Task RemoveTvRequest(int requestId);

        Task<RequestEngineResult> RequestTvShow(SearchTvShowViewModel tv);

        Task<IEnumerable<TvRequests>> SearchTvRequest(string search);

        Task<TvRequests> UpdateTvRequest(TvRequests request);
        Task<IEnumerable<ChildRequests>> GetAllChldren(int tvId);
        Task<ChildRequests> UpdateChildRequest(ChildRequests request);
        Task RemoveTvChild(int requestId);
    }
}