﻿using Microsoft.AspNetCore.Mvc;
using WebEtiqueta.Helpers;
using WebEtiqueta.Models;
using WebEtiqueta.Services;

namespace WebEtiqueta.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                Resposta<MatrizModel> matriz = await _authService.PegarMatrizPorCnpjCpf(id);
                
                if(!matriz.Status)
                {
                    TempData["AlertaTipo"]      = "danger";
                    TempData["AlertaMensagem"]  = matriz.Mensagem;
                    TempData["LogSuporte"]      = matriz.Erro ? matriz.LogSuporte : null;

                    return View("Login");
                }
                
                if (matriz.Status && matriz.Dados != null)
                {
                    ViewBag.Matriz.Nome = matriz.Dados.Nome;
                    ViewBag.Matriz.CnpjCpf = matriz.Dados.CnpjCpf;
                }
            }

            return View("Login");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> ValidarLogin(String usuarioLogin, String usuarioSenha)
        {
            if (string.IsNullOrWhiteSpace(usuarioLogin) || string.IsNullOrWhiteSpace(usuarioSenha))
            {
                return StatusCode(400, new
                {
                    Status      = false,
                    Mensagem    = "Login e Senha são obrigatórios"
                });
            }
            try
            {
                Resposta<UsuarioModel> usuario = await _authService.ValidarLogin(usuarioLogin, usuarioSenha);

                if (!usuario.Status)
                {
                    return StatusCode(401, new
                    {
                        Status = usuario.Status,
                        Mensagem = usuario.Mensagem,
                        LogSuporte = usuario.LogSuporte
                    });
                }

                Resposta<String> jwt = _authService.GerarJwtToken(usuario.Dados);
                if (!jwt.Status)
                {
                    return StatusCode(401, new
                    {
                        Status = jwt.Status,
                        Mensagem = jwt.Mensagem,
                        LogSuporte = jwt.LogSuporte
                    });
                }

                // Criando o cookie
                Response.Cookies.Append("AuthToken", jwt.Dados, new CookieOptions
                {
                    HttpOnly = true,   // Protege contra acesso via JavaScript
                    Secure = false,    // ⚠️ Use `true` em produção (HTTPS)
                    SameSite = SameSiteMode.Lax, // Permite envio em navegação normal
                    Expires = DateTime.UtcNow.AddDays(1) // Tempo de expiração
                });

                HttpContext.Session.SetString("UsuarioNome", usuario.Dados.Nome);
                HttpContext.Session.SetInt32("UsuarioId", usuario.Dados.Id);
                //HttpContext.Session.SetInt32("MatrizCnpjCpf", usuario.dados.MatrizId);

                return StatusCode(200, new
                {
                    Status = true,
                    Mensagem = "Usuário autenticado com sucesso"
                });
            } catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Status = false,
                    Mensagem = "Erro ao autenticar usuário, tente novamente mais tarde ou entre em contato com o suporte",
                    LogSuporte = $"AuthController/ValidarLogin: {e.Message}"
                });
            }
        }

        //[HttpPost]
        //public  IActionResult SenhaSuporte(string? suporteSenha)
        //{
        //    if (string.IsNullOrWhiteSpace(suporteSenha))
        //    {
        //        return StatusCode(400, new
        //        {
        //            Status      = false,
        //            Mensagem    = "Senha de suporte é obrigatória"
        //        });
        //    }

        //    string senha = suporteSenha.Trim();
        //    Resposta<bool> autorizado = _authService.ValidarSenhaSuporte(senha);

        //    if (!autorizado.status)
        //    {
        //        return StatusCode(401, new
        //        {
        //            Status = autorizado.status,
        //            Mensagem = autorizado.mensagem,
        //            LogSuporte = autorizado.logSuporte
        //        });
        //    }

        //    return StatusCode(200);
        //}
    }
}
