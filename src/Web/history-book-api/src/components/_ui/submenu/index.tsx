'use client';

import { AiOutlineApi } from "react-icons/ai";
import { MdDoubleArrow } from "react-icons/md";

export default function SubMenu({ title } : { title: string }) {
    return (
        <div className="flex justify-between items-center text-sm/6 cursor-pointer hover:bg-gray-400/[.4] pl-4 pr-4 pt-3 pb-3 hover:bg-green-500/[.5] hover:text-white">
            <div className="flex items-center gap-2 pl-4">
                <AiOutlineApi size={15} />
                <p className="break-words w-[14rem]">{title}</p>
            </div>
            <div className="group-hover:visible invisible">
                <MdDoubleArrow size={15}  />
            </div>
        </div>
    )
}