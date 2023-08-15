using AutoMapper;

using Northwind.Domain.Production;

namespace Northwind.Application.Production.Categories
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryReadOnlyRepository _readOnlyRepository;
        private readonly ICategoryWriteOnlyRepository _writeOnlyRepository;
        private readonly IMapper _mapper;

        public CategoryAppService(ICategoryReadOnlyRepository readOnlyRepository,
                                  ICategoryWriteOnlyRepository writeOnlyRepository,
                                  IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository ?? throw new ArgumentNullException(nameof(readOnlyRepository));
            _writeOnlyRepository = writeOnlyRepository ?? throw new ArgumentNullException(nameof(writeOnlyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryDetailsDto> Add(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _writeOnlyRepository.Add(category);
            return _mapper.Map<CategoryDetailsDto>(category);
        }

        public async Task<CategoryDetailsDto> Get(int id)
        {
            var category = await _readOnlyRepository.Get(id);
            return _mapper.Map<CategoryDetailsDto>(category);
        }

        public async Task Remove(int id)
        {
            await _writeOnlyRepository.Remove(id);
        }

        public async Task Update(UpdateCategoryDto categoryDto)
        {
            var existingCategory = await _readOnlyRepository.Get(categoryDto.Id);
            if (existingCategory == null) throw new ArgumentException("Category not found");

            _mapper.Map(categoryDto, existingCategory);
            await _writeOnlyRepository.Update(existingCategory);
        }
    }
}