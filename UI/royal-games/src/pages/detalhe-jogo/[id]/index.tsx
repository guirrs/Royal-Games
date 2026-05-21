import Footer from "@/components/footer/footer";
import Header from "@/components/header/header";
import styles from "./detalhe.module.css"
import { useEffect, useState } from "react";
import { useParams } from "next/navigation";
import { listarPorId } from "@/pages/api/jogoService";
import { formatarPreco } from "@/utils/formatar";

interface Jogo {
    nome: string,
    descricao: string,
    preco: number,
    dataLancamento: Date,
    classificacaoId: number,
    imagemUrl: string,
    generos: string[],
    plataforma: string[],
}

const DetalheJogo = () => {

    const [jogo, setJogo] = useState<Jogo>();

    const params = useParams();

    const id = params?.id;

    async function listaJogo() {
        try {
            const response = await listarPorId(Number(id))

            setJogo(response)
        } catch (error: any) {
            console.log(error.message);
        }
    }

    useEffect(() => {
        if (!id) return;

        setTimeout(() => {
            listaJogo();
        }, 1000);
    }, [id])

    return (
        <>
            <Header />
            <article id={styles.container}>
                {jogo ? (<>
                    <div id={styles.conteudo}>
                        <h1>Detalhes do Jogo</h1>
                        <hr></hr>
                        <section className={styles.sobre}>
                            <img src={jogo.imagemUrl} alt="" />
                            <div id={styles.textos}>
                                <h2>{jogo.nome}</h2>
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
                                    <p> Arrumar </p>
                                </div>
                                <div className={styles.campo}>
                                    <h3>Preço:</h3>
                                    <p>{formatarPreco(jogo.preco)}</p>
                                </div>
                            </div>
                            <div id={styles.infoEsquerda}>

                                <div className={styles.campo}>
                                    <h3>Plataformas:</h3>
                                    <ul>
                                        {jogo.plataforma.map((cat) => (
                                            <li key={cat}>{cat}</li>
                                        ))}
                                    </ul>
                                </div>

                                <div className={styles.campo}>
                                    <h3>Gêneros:</h3>
                                    <ul>
                                        {jogo.generos.map((cat) => (
                                            <li key={cat}>{cat}</li>
                                        ))}
                                    </ul>
                                </div>
                            </div>
                        </section>
                    </div>
                </>
                ) : (<section className={styles.sobre}>
                    <p>Carregando jogo...</p>
                </section>)}
            </article>
            <Footer />
        </>
    )
}

export default DetalheJogo;