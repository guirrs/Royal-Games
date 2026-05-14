import Footer from "@/components/footer/footer";
import Header from "@/components/header/header";
import styles from "./detalhe.module.css"

const DetalheJogo = () => {
    return (
        <>
            <Header />
            <article id={styles.container}>
                <div id={styles.conteudo}>
                    <h1>Destalhes do Jogo</h1>
                    <hr></hr>
                    <section id={styles.sobre}>
                        <img src="../imgs/jogo.png" alt="" />
                        <div id={styles.textos}>
                            <h2>Jogo</h2>
                            <p>
                                League of Legends (LoL) é um jogo eletrônico do gênero MOBA (Multiplayer Online Battle Arena) onde duas equipes de cinco jogadores competem entre si com o objetivo de destruir a base adversária. Cada jogador controla um campeão com habilidades únicas, exigindo estratégia, trabalho em equipe e tomada de decisões rápidas durante as partidas.

                                O jogo possui diversos modos, mapas e estilos de jogo, além de oferecer atualizações frequentes com novos personagens, eventos e ajustes de balanceamento. League of Legends é conhecido pelo seu cenário competitivo mundial, reunindo milhões de jogadores e campeonatos profissionais ao redor do mundo.
                            </p>
                        </div>
                    </section>
                    <section id={styles.info}>
                        <div id={styles.infoDireita}>
                            <div className={styles.campo}>
                                <h3>Classificação indicativa:</h3>
                                <p> 18 anos</p>
                            </div>
                            <div className={styles.campo}>
                                <h3>Preço:</h3>
                                <p>R$100,00</p>
                            </div>

                            <div className={styles.campo}>
                                <h3>Plataformas:</h3>
                                <p> XBOX</p>
                            </div>
                        </div>
                        <div id={styles.infoEsquerda}>
                            <div className={styles.campo}>
                                <h3>Categorias:</h3>
                                <p>s</p>
                            </div>

                            <div className={styles.campo}>
                                <h3>Gêneros:</h3>
                                <p></p>
                            </div>
                        </div>
                    </section>
                </div>
            </article>
            <Footer />
        </>
    )
}

export default DetalheJogo;