import styles from "./lista-jogos.module.css"
import CardJogo from "../card-jogo/card-jogo"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import Jogo from "@/pages/jogo"
import { faAngleLeft, faAngleRight } from "@fortawesome/free-solid-svg-icons"
import { excluirJogo, listarJogo } from "@/pages/api/jogoService"
import { useEffect, useState } from "react"
import { erro, notificacao, toastConfirmarExclusao } from "@/utils/toast"
import { verificarAutenticacao } from "@/utils/auth"
import ReactPaginate from "react-paginate"

interface Jogo {
    jogoId: number,
    nome: string,
    preco: number,
    imagemUrl: string,
    statusjogo: boolean
}

interface ListaJogosProps {
    cadastro: boolean;
}


const ListaJogos = ({ cadastro }: ListaJogosProps) => {

    const [jogos, setJogos] = useState<Jogo[]>([]);

    const [ordem, setOrdem] = useState("todos");

    const [pesquisa, setPesquisa] = useState("");

    const [estaAutenticado, setEstaAutenticado] = useState(false);

    // Diz a partir de qual índice da lista o React vai começar a exibir
    const [itemOffset, setItemOffset] = useState(0);

    async function listar() {
        try {
            const lista = await listarJogo();
            setJogos(lista);
        } catch (error: any) {
            console.log(error.message)
        }
    }

    function confirmarExclusao(jogoId: number) {
        toastConfirmarExclusao(async () => {
            try {
                await excluirJogo(jogoId);

                setJogos((listaAtual) =>
                    listaAtual.map((jogo) =>
                        jogo.jogoId === jogoId
                            ? { ...jogo, statusJogo: false }
                            : jogo)
                )
                notificacao("Produto Inativo!")
                listar()
            } catch (error: any) {
                erro(error.message)
            }
        })
    }

    const jogosFiltrados = jogos.filter((jogo) =>
        jogo.nome.toLowerCase().includes(pesquisa.toLowerCase()))
        .sort((a, b) => {
            if (ordem === "menor_valor") {
                return a.preco - b.preco
            }
            else if (ordem === "maior_valor") {
                return b.preco - a.preco
            }
            return a.jogoId - b.jogoId
        })

    // Define que o catálogo vai andar fixo de 3 em 3
    const itensPorPagina = 3;

    // Define onde a fatia da página atual termina (Ex: 0 + 3 = 3)
    const endOffset = itemOffset + itensPorPagina;

    // Cria a lista final contendo APENAS os 3 jogos da página atual
    const jogosPaginados = jogosFiltrados.slice(itemOffset, endOffset);

    // Calcula dinamicamente quantas páginas vão existir (Ex: 9 jogos / 3 = 3 páginas)
    const totalPaginas = Math.ceil(jogosFiltrados.length / itensPorPagina);

    // Função que roda toda vez que o usuário clica em um número novo
    const handlePageClick = (event: { selected: number }) => {
        const novoOffset = (event.selected * itensPorPagina) % jogosFiltrados.length;
        setItemOffset(novoOffset);
    };

    useEffect(() => {
        setEstaAutenticado(verificarAutenticacao());
        listar()
    }, [])

    return (
        <div id={styles.container}>
            <h2>Catálogo de jogos</h2>
            <hr></hr>
            <div id={styles.filtros}>
                <input type="text" placeholder="Pesquisar..." value={pesquisa} onChange={(e) => { setPesquisa(e.target.value) }} />
                <select value={ordem} onChange={(e) => setOrdem(e.target.value)}>
                    <option value="todos">Todos os produtos</option>
                    <option value="menor_valor">Menor valor</option>
                    <option value="maior_valor">Maior valor</option>
                </select>
                <button>Categoria</button>
            </div>
            <div id={styles.jogos}>
                {jogosPaginados.length > 0 ? jogosPaginados.map((item) => (
                    <CardJogo
                        key={item.jogoId}
                        jogoID={item.jogoId}
                        nome={item.nome}
                        image={item.imagemUrl}
                        preco={item.preco}
                        paginaJogo={cadastro}
                        onDelete={confirmarExclusao}
                    />

                )) : (
                    <p>Carregando produto</p>
                )}
            </div>
            <div id={styles.trocaEl}>
                <ReactPaginate
                    breakLabel="..."
                    previousLabel={<FontAwesomeIcon icon={faAngleLeft} className={styles.seta} />}
                    nextLabel={<FontAwesomeIcon icon={faAngleRight} className={styles.seta} />}
                    onPageChange={handlePageClick}
                    pageRangeDisplayed={3}
                    pageCount={totalPaginas}

                    containerClassName={styles.paginacaoLista}
                    pageClassName={styles.itemNumero}
                    pageLinkClassName={styles.botaoTroca}
                    activeClassName={styles.paginaAtiva}
                    disabledClassName={styles.setaDesativada}
                />
            </div>
        </div>
    )
}

export default ListaJogos