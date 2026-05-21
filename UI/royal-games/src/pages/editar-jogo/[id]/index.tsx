import Formulario from "@/components/formulario"
import Footer from "@/components/footer/footer"
import HeaderCadastro from "@/components/header-cadastro/header-cadastro"
import style from "./editar.module.css"

const Edicao = () => {
    return (
        <main id={style.editar}>
            <HeaderCadastro />
            <Formulario />
            <Footer />
        </main>
    )
}

export default Edicao