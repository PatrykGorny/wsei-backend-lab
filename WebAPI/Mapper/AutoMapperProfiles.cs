using ApplicationCore.Models;
using ApplicationCore.Models.QuizAggregate;
using AutoMapper;
using WebAPI.Dto;

namespace WebAPI.Mapper;

public class AutoMapperProfiles: Profile
{
    
    public AutoMapperProfiles()
    {
        CreateMap<QuizItem, QuizItemDto>()
            .ForMember(
                q => q.Options,
                op => op.MapFrom(i => new List<string>(i.IncorrectAnswers) { i.CorrectAnswer }));
        CreateMap<Quiz, QuizDto>()
            .ForMember(
                q => q.Items,
                op => op.MapFrom<List<QuizItem>>(i => i.Items)
            );
        CreateMap<NewQuizDto, Quiz>()
            .ForMember(q => q.Items, op => op.MapFrom(dto => dto.Items)); 
        
        CreateMap<QuizItemUserAnswer, FeedbackQuizItemDto>()
            .ForMember(dest => dest.QuizItemId, opt => opt.MapFrom(src => src.QuizItem.Id))
            .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer))
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.QuizItem.Question))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect())); 

    }
}