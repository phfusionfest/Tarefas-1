﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Application.Interfaces;
using Tarefas.Application.ViewModels;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Services;
using Tarefas.Infrastructure.Data.Interfaces;

namespace Tarefas.Application.Services
{
    public class TarefaAppService : ApplicationServiceBase, ITarefaAppService
    {
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefaAppService(ITarefaService tarefaService, IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _tarefaService = tarefaService;
            _mapper = mapper;
        }

        public void Adicionar(TarefaViewModel tarefa)
        {
            try
            {
                _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefa));
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }
        }

        public void Atualizar(TarefaViewModel tarefa)
        {
            try
            {
                _tarefaService.Atualizar(_mapper.Map<Tarefa>(tarefa));
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }
        }

        public void Remover(TarefaViewModel tarefa)
        {
            try
            {
                _tarefaService.Remover(_mapper.Map<Tarefa>(tarefa));
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }
        }

        public async Task<IEnumerable<TarefaViewModel>> BuscarTarefasAtivas()
        {
            var tarefasAtivas = new List<TarefaViewModel>();

            try
            {
                tarefasAtivas = _mapper.Map<List<TarefaViewModel>>(await _tarefaService.BuscarTarefasAtivas());
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return tarefasAtivas;
        }

        public void Dispose()
        {
            _tarefaService.Dispose();
        }
    }
}