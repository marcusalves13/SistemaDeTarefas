﻿using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTarefas
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em Andamento")]
        EmAndamento =2,
        [Description("Concluido")]
        Concluido =3
    }
}
