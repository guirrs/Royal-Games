import Footer from "@/components/footer/footer";
import HeaderCadastro from "@/components/header-cadastro/header-cadastro";
import ListaJogos from "@/components/lista-jogos/lista-jogos";
import styles from "./cadastro.module.css"

const Cadastro = () => {
    return (
        <main id={styles.pagina}>
            <HeaderCadastro />
            <section id={styles.cadastro}>
                <div id={styles.titulo}>
                    <h1>Cadastrar novo jogo</h1>
                    <hr></hr>
                </div>
                <div id={styles.camposInfos}>
                    <div id={styles.campoEsquerdo}>
                        <div className={`${styles.campo} ${styles.nome}`}>
                            <label htmlFor="">Nome</label>
                            <input type="text" />
                        </div>
                        <div className={styles.linha}>
                            <div className={`${styles.campo} ${styles.valor}`}>
                                <label htmlFor="">Valor</label>
                                <input type="text" />
                            </div>
                            <div className={styles.botaoInput}>
                                <label htmlFor="Genero">Gênero</label>
                                <button></button>
                            </div>
                            <div className={styles.botaoInput}>
                                <label htmlFor="Clasificação Indicativa">Clasificação Indicativa</label>
                                <button></button>
                            </div>
                        </div>
                        <div className={styles.linha}>
                            <div className={styles.botaoInput}>
                                <label htmlFor="Plataforma">Plataforma</label>
                                <button></button>
                            </div>
                            <div className={`${styles.campo} ${styles.imagem}`}>
                                <label htmlFor="">Imagem</label>
                                <input type="image" />
                            </div>
                        </div>
                    </div>
                    <div id={styles.campoDireito}>
                        <label htmlFor="">Descrição</label>
                        <input type="text" />
                    </div>
                </div>

                <button id={styles.botaoCadastro}>Cadastro</button>

            </section>

            <ListaJogos />
            <Footer />
        </main>
    )
}

export default Cadastro;