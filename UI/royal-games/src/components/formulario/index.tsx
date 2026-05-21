import { listarPlataforma } from "@/pages/api/plataformaService"
import styles from "./formulario.module.css"
import { ListarClassificacao } from "@/pages/api/classificacaoService"
import { listarGenero } from "@/pages/api/generoService"
import { cadastrarJogo, editarJogo, listarPorId } from "@/pages/api/jogoService"
import { useRouter } from "next/router"
import { useEffect, useState } from "react"
import { erro, notificacao } from "@/utils/toast"
import { verificarAutenticacao } from "@/utils/auth"
import { ToastContainer } from "react-toastify"

interface Genero {
    generoID: number;
    nome: string;
}

interface Plataforma {
    plataformaID: number;
    nome: string;
}

interface Classificaco {
    id: number;
    faixa: string;
}

const Formulario = () => {
    // Listas de opções dos selects
    const [genero, setGenero] = useState<Genero[]>([])
    const [plataforma, setPlataforma] = useState<Plataforma[]>([]);
    const [classificacao, setClassificacao] = useState<Classificaco[]>([]);

    // Valores controlados do formulário
    const [nome, setNome] = useState<string>("");
    const [preco, setPreco] = useState<string>("");
    const [generosSelecionados, setGenerosSeleciondado] = useState<number[]>([]);
    const [plataformaSelecionados, setPlataformaSeleciondado] = useState<number[]>([]);
    const [classificacaoSelecionados, setClassificacaoSelecionados] = useState<number>(1);
    const [descricao, setDescricao] = useState<string>("");
    const [image, setImage] = useState<File | null>(null);

    const [estaAutenticado, setEstaAutenticado] = useState(false);

    const router = useRouter();
    const id  = router.query.id;

    async function carregarInformacoes() {
        if (!id || isNaN(Number(id))) return;

        try {
            const jogo = await listarPorId(Number(id));
            
            if (jogo) {
                setNome(jogo.nome ?? "");
                setDescricao(jogo.descricao ?? "");
                setPreco(jogo.preco ?? "");
                
                setGenerosSeleciondado(jogo.generosId ?? (jogo.generoID ? [Number(jogo.generoID)] : []));
                setPlataformaSeleciondado(jogo.plataformaId ?? (jogo.plataformaID ? [Number(jogo.plataformaID)] : []));
                setClassificacaoSelecionados(Number(jogo.classificacaoId ?? 1));
            }
        } catch (error: any) {
            console.log("Erro ao carregar dados de edição:", error.message);
        }
    }

    async function listarGeneroJogo() {
        try {
            const listaGenero = await listarGenero();
            setGenero(listaGenero.data ?? []);
        } catch (error: any) {
            console.log(error.message);
        }
    }

    async function listarClassificacaoJogo() {
        try {
            const listarClassificacao = await ListarClassificacao();
            setClassificacao(listarClassificacao.data ?? []);
        } catch (error: any) {
            console.log(error.message);
        }
    }

    async function listarPlataformaJogo() {
        try {
            const listaPlataforma = await listarPlataforma();
            setPlataforma(listaPlataforma.data ?? []);
        } catch (error: any) {
            console.log(error.message);
        }
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

            if (id) {
                // Se existe ID na URL, estamos editando!
                await editarJogo(Number(id), dados);
                notificacao("Jogo atualizado com sucesso!");
            } else {
                await cadastrarJogo(dados);
                notificacao("Jogo cadastrado com sucesso!");
            }
        } catch (error: any) {
            erro(error.message);
        }
    }

    useEffect(() => {
        if (!router.isReady) return;

        if (!verificarAutenticacao()) {
            router.push("/home");
            return;
        }

        setEstaAutenticado(true);

        // Carrega os dados estruturais do banco (Selects)
        listarGeneroJogo();
        listarPlataformaJogo();
        listarClassificacaoJogo();

        // Tenta preencher em caso de edição
        carregarInformacoes();

    }, [router.isReady, id])

    if (!estaAutenticado) return null;

    return (
        <section id={styles.cadastro}>
            <ToastContainer />
            <div id={styles.titulo}>
                <h1>{id ? "Editar jogo" : "Cadastrar novo jogo"}</h1>
                <hr />
            </div>
            <form id={styles.camposInfos} onSubmit={salvarJogo}>
                <div id={styles.campoEsquerdo}>
                    <div className={`${styles.campo} ${styles.nome}`}>
                        <label>Nome</label>
                        <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} />
                    </div>
                    <div className={styles.linha}>
                        <div className={`${styles.campo} ${styles.valor}`}>
                            <label>Valor</label>
                            <input type="text" value={preco} onChange={(e) => setPreco(e.target.value)} />
                        </div>
                        <div className={styles.botaoInput}>
                            <label htmlFor="Genero">Gênero</label>
                            <select 
                                multiple 
                                value={(generosSelecionados ?? []).map(String)}
                                onChange={(e) => setGenerosSeleciondado(
                                    Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                )}
                            >
                                {(genero ?? []).map((item) => (
                                    <option value={item.generoID} key={item.generoID}>{item.nome}</option>
                                ))}
                            </select>
                        </div>
                        <div className={styles.botaoInput}>
                            <label htmlFor="Clasificação Indicativa">Classificação Indicativa</label>
                            <select 
                                value={classificacaoSelecionados}
                                onChange={(e) => setClassificacaoSelecionados(Number(e.target.value))}
                            >
                                {(classificacao ?? []).map((item) => (
                                    <option key={item.id} value={item.id}>{item.faixa}</option>
                                ))}
                            </select>
                        </div>
                    </div>
                    <div className={styles.linha}>
                        <div className={styles.botaoInput}>
                            <label htmlFor="Plataforma">Plataforma</label>
                            <select 
                                multiple 
                                value={(plataformaSelecionados ?? []).map(String)}
                                onChange={(e) => setPlataformaSeleciondado(
                                    Array.from(e.target.selectedOptions).map((option) => Number(option.value))
                                )}
                            >
                                {(plataforma ?? []).map((item) => (
                                    <option key={item.plataformaID} value={item.plataformaID}>{item.nome}</option>
                                ))}
                            </select>
                        </div>
                        <div className={`${styles.campo} ${styles.imagem}`}>
                            <label>Imagem</label>
                            <input type="file" onChange={(e) => {
                                if (e.target.files && e.target.files[0]) {
                                    setImage(e.target.files[0]);
                                }
                            }} />
                        </div>
                    </div>
                </div>
                <div id={styles.campoDireito}>
                    <label>Descrição</label>
                    <input type="text" value={descricao} onChange={(e) => setDescricao(e.target.value)} />
                </div>

                <button id={styles.botaoCadastro}>{id ? "Salvar Alterações" : "Cadastro"}</button>
            </form>
        </section>
    );
};

export default Formulario;