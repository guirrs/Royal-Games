import Footer from "@/components/footer/footer";
import HeaderCadastro from "@/components/header-cadastro/header-cadastro";
import ListaJogos from "@/components/lista-jogos/lista-jogos";
import styles from "./cadastro.module.css"
import { useEffect, useState } from "react";
import { useRouter } from "next/router";
import { cadastrarJogo, editarJogo, listarPorId } from "../api/jogoService";
import { erro, notificacao } from "@/utils/toast";
import { ToastContainer } from "react-toastify";
import { listarGenero } from "../api/generoService";
import { listarPlataforma } from "../api/plataformaService";
import { ListarClassificacao } from "../api/classificacaoService";
import { verificarAutenticacao } from "@/utils/auth";

interface Genero {
    generoID: number,
    nome: string
}

interface Plataforma {
    plataformaID: number,
    nome: string
}

interface Classificaco {
    id: number,
    faixa: string
}

const Cadastro = () => {

    const [genero, setGenero] = useState<Genero[]>([])
    const [plataforma, setPlataforma] = useState<Plataforma[]>([]);
    const [classificacao, setClassificacao] = useState<Classificaco[]>([]);

    const [nome, setNome] = useState<string>("");
    const [preco, setPreco] = useState<string>("");
    const [generosSelecionados, setGenerosSeleciondado] = useState<number[]>([]);
    const [plataformaSelecionados, setPlataformaSeleciondado] = useState<number[]>([]);
    const [classificacaoSelecionados, setClassificacaoSelecionados] = useState<number>(1);
    const [descricao, setDescricao] = useState<string>("");
    const [image, setImage] = useState<File | null>(null);

    const [estaAutenticado, setEstaAutenticado] = useState(false);

    const router = useRouter();
    const id = router.query.id;
    let telaEditar = id ? true : false;

    async function carregarInformacoes() {
        if (!id) return;

        const jogo = await listarPorId(Number(id))
        setNome(jogo.nome);
        setDescricao(jogo.descricao);
        setPreco(jogo.preco);
        setGenero(jogo.generoID);
        setPlataforma(jogo.plataformaID);
        setClassificacao(jogo.classificacaoId);
    }

    async function listarGeneroJogo() {
        const listaGenero = await listarGenero();
        setGenero(listaGenero.data)
    }

    async function listarClassificacaoJogo() {
        const listarClassificacao = await ListarClassificacao();
        setClassificacao(listarClassificacao.data);
    }

    async function listarPlataformaJogo() {
        const listaPlataforma = await listarPlataforma();
        setPlataforma(listaPlataforma.data)
    }

    async function salvarJogo(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        try {
            const dados = {
                nome,
                descricao,
                preco,
                classificacaoId: classificacaoSelecionados,
                image,
                generosId: generosSelecionados,
                plataformaId: plataformaSelecionados
            }

            if (telaEditar) {
                await editarJogo(Number(id), dados)
                notificacao("Jogo editado");
            } else {
                await cadastrarJogo(dados);
                notificacao("Jogo cadastrado");
            }
        } catch (error: any) {
            erro(error.message);
        }
    }

    useEffect(() => {
        if (!router.isReady) return;

        if (!verificarAutenticacao()) {
            router.push("/home")
            return;
        }

        setEstaAutenticado(true);

        listarGeneroJogo();
        listarPlataformaJogo();
        listarClassificacaoJogo();

        carregarInformacoes();

    }, [router.isReady, id])

    if (!estaAutenticado)
        return null

    return (
        <main id={styles.pagina}>
            <HeaderCadastro />
            <ToastContainer />
            <section id={styles.cadastro}>
                <div id={styles.titulo}>
                    <h1>Cadastrar novo jogo</h1>
                    <hr></hr>
                </div>
                <form id={styles.camposInfos} onSubmit={salvarJogo}>
                    <div id={styles.campoEsquerdo}>
                        <div className={`${styles.campo} ${styles.nome}`}>
                            <label htmlFor="">Nome</label>
                            <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} />
                        </div>
                        <div className={styles.linha}>
                            <div className={`${styles.campo} ${styles.valor}`}>
                                <label htmlFor="">Valor</label>
                                <input type="text" value={preco} onChange={(e) => setPreco(e.target.value)} />
                            </div>
                            <div className={styles.botaoInput}>
                                <label htmlFor="Genero">Gênero</label>
                                <select multiple value={generosSelecionados.map(String)}
                                    onChange={(e) => setGenerosSeleciondado
                                        (Array.from(e.target.selectedOptions).map((option) => Number(option.value)))}
                                >
                                    {genero.map((item) => (
                                        <option value={item.generoID} key={item.generoID}>{item.nome}</option>
                                    ))}
                                </select>
                            </div>
                            <div className={styles.botaoInput}>
                                <label htmlFor="Clasificação Indicativa">Clasificação Indicativa</label>
                                <select value={classificacaoSelecionados}
                                    onChange={(e) => setClassificacaoSelecionados
                                        (Number(e.target.value))}
                                >
                                    {classificacao.map((item) => (
                                        <option key={item.id} value={item.id}>{item.faixa}</option>
                                    ))}
                                </select>
                            </div>
                        </div>
                        <div className={styles.linha}>
                            <div className={styles.botaoInput}>
                                <label htmlFor="Plataforma">Plataforma</label>
                                <select multiple value={plataformaSelecionados.map(String)}
                                    onChange={(e) => setPlataformaSeleciondado
                                        (Array.from(e.target.selectedOptions).map((option) => Number(option.value)))}
                                >
                                    {plataforma.map((item) => (
                                        <option key={item.plataformaID} value={item.plataformaID}>{item.nome}</option>
                                    ))}
                                </select>
                            </div>
                            <div className={`${styles.campo} ${styles.imagem}`}>
                                <label htmlFor="">Imagem</label>
                                <input type="file" onChange={(e) => {
                                    if (e.target.files && e.target.files[0]) {
                                        setImage(e.target.files[0]);
                                    }
                                }} />
                            </div>
                        </div>
                    </div>
                    <div id={styles.campoDireito}>
                        <label htmlFor="">Descrição</label>
                        <input type="text" value={descricao} onChange={(e) => setDescricao(e.target.value)} />
                    </div>

                    <button id={styles.botaoCadastro}>Cadastro</button>

                </form>


            </section>

            <ListaJogos 
            cadastro = {true}/>
            <Footer />
        </main>
    )
}

export default Cadastro;