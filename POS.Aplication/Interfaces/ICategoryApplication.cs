using POS.Aplication.Comnons.Bases;
using POS.Aplication.Dtos.Request;
using POS.Aplication.Dtos.Response;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;

namespace POS.Aplication.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);

    }
}
