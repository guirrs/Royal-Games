import styles from "./header.module.css"

const Header = () => {
    return (
        <header id={styles.main}>
            < img src="../imgs/logo.png" alt="" />
            <div>
                <a href="">Cadastrar jogos</a>
                <a href="">Catálogo</a>
                <a href="">Login</a>
            </div>
        </header>
    )
}

export default Header;