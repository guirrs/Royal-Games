import Header from "@/components/header/header";
import styles from "./home.module.css"
import Footer from "@/components/footer/footer";

const Home = () => {
    return (
        <>
        <div id={styles.container}>
            <Header />
            <Footer/>
        </div>
        </>
    )
}

export default Home;