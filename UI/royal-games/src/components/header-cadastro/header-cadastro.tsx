import styles from "./header-cadastro.module.css"

const HeaderCadastro = () =>{
    return(
        <>
            <header id={styles.main}>
            < img src="../imgs/logo.png" alt="" />
            <div>
                <a href="">Jogos</a>
                <a href="">Deslogar</a>
            </div>
        </header>
        </>
    )
}

export default HeaderCadastro