import React, { useContext } from "react";
import { globalContext } from "../Pages/Navbar";
import {
    IconButton,
    Typography,
    List,
    ListItem,
    ListItemPrefix,
    Accordion,
    AccordionHeader,
    AccordionBody,
    Alert,
    Input,
    Drawer,
    Card,
} from "@material-tailwind/react";
import {
    ShoppingBagIcon,
    UserCircleIcon,
    Cog6ToothIcon,
} from "@heroicons/react/24/solid";
import {
    ChevronRightIcon,
    ChevronDownIcon,
    MagnifyingGlassIcon,
    Bars3Icon,
    XMarkIcon,
} from "@heroicons/react/24/outline";
import { Link}  from "react-router-dom";
import { useNavigate } from "react-router-dom";


export function Sidebar() {
    const navigate = useNavigate();
    const [open, setOpen] = React.useState(0);
    const [openAlert, setOpenAlert] = React.useState(true);
    const [isDrawerOpen, setIsDrawerOpen] = React.useState(false);
    const { productType, setProductType } = useContext(globalContext)

    const handleOpen = (value) => {
        setOpen(open === value ? 0 : value);
    };
    const filterProducts=(event)=>{
        setProductType(event.target.innerText);
        navigate("/products");
        closeDrawer();
       
    }

    const openDrawer = () => setIsDrawerOpen(true);
    const closeDrawer = () => setIsDrawerOpen(false);

    return (
        <> 
            <IconButton variant="text" size="lg" onClick={openDrawer}>
                {isDrawerOpen ? (
                    <IconButton>
                    <XMarkIcon className="h-8 w-8 stroke-2" />
                    </IconButton>
                ) : (
                    <Bars3Icon className="h-8 w-8 stroke-2" />
                )}
            </IconButton>
            <Drawer open={isDrawerOpen} onClose={closeDrawer} className="bg-gradient-to-b from-emerald-200 to-purple-400">
                <Card
                    color="transparent"
                    shadow={false}
                    className="h-[calc(100vh-2rem)] w-full p-4 "
                    
                >
                    <IconButton  variant="text" size="lg" onClick={closeDrawer}>
                    <XMarkIcon className="h-8 w-8 stroke-2"/>
                    </IconButton>
                    <div className="mb-2 flex items-center gap-4 p-4">
                        <Typography variant="h5" color="blue-gray" className="underline decoration-double uppercase ">
                            OfferOasis Sidebar
                        </Typography>
                    </div>
                    <div className="p-2" >
                        <Input
                            icon={<MagnifyingGlassIcon className="h-5 w-5" />}
                            label="Search"
                        />
                    </div>
                    <List>
                        <Accordion
                            open={open === 1}
                            icon={
                                <ChevronDownIcon
                                    strokeWidth={2.5}
                                    className={`mx-auto h-4 w-4 transition-transform ${open === 1 ? "rotate-180" : ""
                                        }`}
                                />
                            }
                        >
                            <ListItem className="p-0" selected={open === 1}>
                            </ListItem>
                        </Accordion>
                        <Accordion
                            open={open === 2}
                            icon={
                                <ChevronDownIcon
                                    strokeWidth={2.5}
                                    className={`mx-auto h-4 w-4 transition-transform ${open === 2 ? "rotate-180" : ""
                                        }`}
                                />
                            }
                        >
                            <ListItem className="p-0" selected={open === 2}>
                                <AccordionHeader
                                    onClick={() => handleOpen(2)}
                                    className="border-b-0 p-3"
                                >
                                    <ListItemPrefix>
                                        <ShoppingBagIcon className="h-5 w-5" />
                                    </ListItemPrefix>
                                    <Typography color="blue-gray" className="mr-auto font-normal">
                                       Our Products
                                    </Typography>
                                </AccordionHeader>
                            </ListItem>
                            <AccordionBody className="py-1">
                                <List className="p-0">
                                    <ListItem onClick={(e)=>{filterProducts(e)}}>
                                        <ListItemPrefix>
                                            <ChevronRightIcon strokeWidth={3} className="h-3 w-5" />
                                        </ListItemPrefix>
                                       Phone
                                    </ListItem>
                                </List>
                                <List className="p-0">
                                    <ListItem onClick={(e)=>filterProducts(e)}>
                                        <ListItemPrefix>
                                            <ChevronRightIcon strokeWidth={3} className="h-3 w-5" />
                                        </ListItemPrefix>
                                        Laptop
                                    </ListItem>
                                </List>
                                <List className="p-0">
                                    <ListItem onClick={(e)=>filterProducts(e)}>
                                        <ListItemPrefix>
                                            <ChevronRightIcon strokeWidth={3} className="h-3 w-5" />
                                        </ListItemPrefix>
                                     Speaker
                                    </ListItem>
                                </List>
                                <List className="p-0">
                                    <ListItem onClick={(e)=>filterProducts(e)}>
                                        <ListItemPrefix>
                                            <ChevronRightIcon strokeWidth={3} className="h-3 w-5" />
                                        </ListItemPrefix>
                                     Clothing
                                    </ListItem>
                                </List>
                                <List className="p-0">
                                    <ListItem onClick={(e)=>filterProducts(e)}>
                                        <ListItemPrefix>
                                            <ChevronRightIcon strokeWidth={3} className="h-3 w-5" />
                                        </ListItemPrefix>
                                     Misc
                                    </ListItem>
                                </List>
                            </AccordionBody>
                        </Accordion>
                        <hr className="my-2 border-blue-gray-50" />
                        <Link to="/cart" >
                        <ListItem onClick={() => closeDrawer()}>
                            <ListItemPrefix>
                                <UserCircleIcon className="h-5 w-5" />
                            </ListItemPrefix>
                            Profile
                        </ListItem>
                        </Link>
                        <Link to="/contact">
                        <ListItem onClick={() => closeDrawer()}>
                            <ListItemPrefix>
                                <Cog6ToothIcon className="h-5 w-5" />
                            </ListItemPrefix>
                            Contact
                        </ListItem>
                        </Link>
                        <Link to="/about">
                        <ListItem onClick={() => closeDrawer()}>
                            <ListItemPrefix>
                                <Cog6ToothIcon className="h-5 w-5" />
                            </ListItemPrefix>
                            About Us
                        </ListItem>
                        </Link>
                    </List>
                </Card>
            </Drawer>
            
        </>
    );
}