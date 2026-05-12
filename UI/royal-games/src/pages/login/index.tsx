import styles from "./login.module.css"

const Login = () => {
    return (
        <body>
            <section id={styles.container}>
            <img src="../imgs/mulherLogin.png" alt="" id={styles.mulher}/>
            <div id={styles.caixa}>
                <img src="../imgs/logo.png" alt="" />
                <div className={styles.campo}>
                    <label htmlFor="email">Email</label>
                    <input type="text" name="email" placeholder="email@gmail.com"/>
                </div>
                <div className={styles.campo}>
                    <label htmlFor="senha">Senha</label>
                    <input type="text" name="password" placeholder="***********"/>
                </div>
                <button>Entrar</button>
            </div>
            </section>
        </body>
    )
}


export default Login;