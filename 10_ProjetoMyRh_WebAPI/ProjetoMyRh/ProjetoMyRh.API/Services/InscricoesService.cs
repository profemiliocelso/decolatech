﻿using ProjetoMyRh.API.Models.Contexts;
using ProjetoMyRh.API.Models.DTO;

namespace ProjetoMyRh.API.Services
{
    public class InscricoesService
    {
        private MyRhContext myRhContext { get; set; }
        public InscricoesService(MyRhContext context)
        {
            this.myRhContext = context;
        }

        // método para listar todas as inscrições 
        public IEnumerable<InscricoesDTO> ListarInscricoes() 
        {
            var lista = from crg in myRhContext.Cargos
                        join ins in myRhContext.Inscricoes on crg.Id equals ins.CargoId
                        join cdt in myRhContext.Candidatos on ins.Cpf equals cdt.Cpf
                        select new InscricoesDTO
                        {
                            IdInscricao = ins.Id,
                            Candidato = cdt.Nome,
                            Cargo = crg.Descricao,
                            DataInscricao = ins.DataInscricao,
                            Salario = crg.Salario
                        };
            return lista.ToList();

        }
    }
}
