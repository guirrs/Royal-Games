import Link from "next/link"
import styles from "./header-cadastro.module.css"

const HeaderCadastro = () =>{
    return(
        <>
            <header id={styles.main}>
            <Link href="/home">
                < img src="../imgs/logo.png" alt="" />
            </Link>
            <div>
                <a href="">Jogos</a>
                <a href="">Deslogar</a>
            </div>
        </header>
        </>
    )
}

export default HeaderCadastro