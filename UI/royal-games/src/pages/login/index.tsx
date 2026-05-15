import { useState } from "react";
import styles from "./login.module.css"
import { useRouter } from "next/router";
import { login } from "../api/authService";
import { ToastContainer, toast } from "react-toastify";
import { emit } from "process";

const Login = () => {

    const [email, setEmail] = useState<string>("");
    const [senha, setSenha] = useState<string>("");

    const router = useRouter();
    const notificacao = (msg:string) => toast.success(msg);
    const erro = (msg:string) => toast.error(msg)

    async function autentificar(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        try{
            await login(email, senha);
            
            notificacao("Login bem sucedido!")
            setTimeout(() => {
                router.push("/home")
        }, 2000);
        }catch(error: any){
            erro(error.message)
        }
    }

    return (
        <>
            <ToastContainer/>
            <section id={styles.container}>
            <img src="../imgs/mulherLogin.png" alt="" id={styles.mulher}/>
            <form id={styles.caixa} onSubmit={autentificar}>
                <img src="../imgs/logo.png" alt="" />
                <div className={styles.campo}>
                    <label htmlFor="email">Email</label>
                    <input type="text" value={email} onChange={(e) => setEmail(e.target.value)} name="email" placeholder="email@gmail.com"/>
                </div>
                <div className={styles.campo}>
                    <label htmlFor="senha">Senha</label>
                    <input type="text" value={senha} onChange={(e) => setSenha(e.target.value)} name="password" placeholder="***********"/>
                </div>
                <button>Entrar</button>
            </form>
            </section>
        </>
    )
}


export default Login;