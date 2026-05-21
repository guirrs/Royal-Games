import Link from "next/link";
import styles from "./header.module.css"

const Header = () => {
    return (
        <header id={styles.main}>
            <Link href="/home">
                < img src="../imgs/logo.png" alt="" />
            </Link>
            <div>
                <a href="">Catálogo</a>
                <Link href="/login">Login</Link>
            </div>
        </header>
    )
}

export default Header;