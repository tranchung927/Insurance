// ** Custom Menu Components
import MainNavLink from './MainNavLink'

const MainNavItems = props => {
    // ** Props
    const { navItems } = props

    const RenderMenuItems = navItems?.map((item, index) => {
        if (item.items) {

        }
        return <MainNavLink {...props} key={index} item={item} />
    })

    return <>{RenderMenuItems}</>
}

export default MainNavItems