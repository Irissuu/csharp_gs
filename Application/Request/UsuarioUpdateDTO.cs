﻿namespace FlowGuard.Application.Request
{
    public class UsuarioUpdateDTO
    {
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}
