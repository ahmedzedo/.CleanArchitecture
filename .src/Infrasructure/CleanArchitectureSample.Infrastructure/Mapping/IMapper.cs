using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Infrastructure.Mapping
{
   public interface IMapper<TViewModel,TModel>
    {
        TViewModel ToViewModel(TModel model);
        TModel ToModel(TViewModel viewModel);
        //IEnumerable<TViewModel> ToViewModel(IEnumerable<TModel> modelList);
        //IEnumerable<TModel> ToModel(IEnumerable<TViewModel> viewModelList);

    }
}
