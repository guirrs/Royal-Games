import Footer from "@/components/footer/footer";
import ListaJogos from "@/components/lista-jogos/lista-jogos";
import styles from "./cadastro.module.css"
import Formulario from "@/components/formulario";
import HeaderCadastro from "@/components/header-cadastro/header-cadastro";

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
    return (
        <main id={styles.pagina}>
            <HeaderCadastro/>
            <Formulario/>
            <ListaJogos
                cadastro={true} />
            <Footer />
        </main>
    )
}

export default Cadastro;