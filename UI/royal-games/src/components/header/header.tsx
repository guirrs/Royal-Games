import Link from "next/link";
import styles from "./header.module.css"

const Header = () => {
    return (
        <header id={styles.main}>
            < img src="../imgs/logo.png" alt="" />
            <div>
                <a href="">Catálogo</a>
                <Link href="/login">Login</Link>
            </div>
        </header>
    )
}

export default Header;