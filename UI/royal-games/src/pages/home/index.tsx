import Header from "@/components/header/header";
import styles from "./home.module.css"
import Footer from "@/components/footer/footer";
import ListaJogos from "@/components/lista-jogos/lista-jogos";

const pagina = false;

const Home = () => {
    return (
        <>
            <div id={styles.container}>
                <Header />
                <section id={styles.banner}>
                        <div id={styles.texto_banner}>
                            <h1>Conheça nossos jogos!</h1>
                            <p>Navegue por títulos de todas as gerações, descubra plataformas, gêneros e detalhes completos antes de escolher sua próxima aventura. Seu próximo jogo favorito começa aqui.</p>
                        </div>
                        <img src="../imgs/aura.png" alt="" />
                </section>
                <section id={styles.listaJogos}>
                    <ListaJogos 
                    cadastro = {false}
                    />
                </section>
                <section id={styles.noticia}>
                    <h2>Jogos online podem afetar o comportamento humano?</h2>
                        <hr></hr>
                    <div>
                        <img src="../imgs/cs.png" alt="" />
                        <img src="../imgs/cs.png" alt="" />
                    </div>
                    <p> Estudos indicam que jogos podem alterar o comportamento humano…
                        Principalmente quando o time resolve testar sua paciência em plena partida ranqueada.</p>
                
                </section>
                <Footer />
            </div>
        </>
    )
}

export default Home;