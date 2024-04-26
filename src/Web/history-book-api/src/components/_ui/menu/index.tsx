'use client';

import { useContext, useState } from "react";
import { AiOutlineApi } from "react-icons/ai"
import { IoIosArrowDown, IoIosArrowForward } from "react-icons/io"
import { MdDoubleArrow } from "react-icons/md"
import SubMenu from "../submenu";
import { AplicationContext } from "@/contexts/appContext";

export default function Menu({ title, onClick } : { title: string, onClick?: undefined | ((router: any, method: string) => void) }) {
    const [open, setOpen] = useState<boolean>(false);
    const {
        getPaths,
        getRouters,
        formatResponses,
        getSchema,
        apiDatas
      } = useContext(AplicationContext);

    return (
        <div className={`flex flex-col`} onClick={() => { setOpen(!open) }}>
            <div className={`flex justify-between items-center text-sm/6 cursor-pointer hover:bg-gray-400/[.4] pl-4 pr-4 pt-3 pb-3 hover:bg-green-500 hover:text-white ${open ? 'bg-green-500 text-white' : ''}`}>
                <div className="flex items-center gap-2">
                    <AiOutlineApi size={15} />
                    {title}
                </div>
                {open ? <IoIosArrowDown size={15} /> : <IoIosArrowForward size={15} />}
            </div>
            <div className="bg-green-700 text-white" hidden={!open}>
                <ul>
                    {
                        getRouters(title).map((router: any) => {
                            return router.routers.map((method: any, index: number) => {
                                return (<li className="group" key={index} onClick={() => { 
                                    if(onClick != undefined) {
                                        onClick(router, method.method);
                                    }
                                }}><SubMenu title={router.key + " - "+ method.method.toUpperCase()} key={1} /></li>)
                            })
                        })
                    }
                </ul>
            </div>
        </div>
    )
}

