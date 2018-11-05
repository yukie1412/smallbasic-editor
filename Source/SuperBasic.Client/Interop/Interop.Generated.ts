/*!
 * Copyright (c) 2018 Omar Tawfik. All rights reserved. Licensed under the MIT License. See LICENSE file in the project root for license information.
 */

/// <summary>
/// This file is auto-generated by a build task. It shouldn't be edited by hand.
/// </summary>
import { JSInterop } from "./JSInterop";
import { MonacoInterop } from "./MonacoInterop";

export interface IJSInterop {
    initializeWebView(locale: string, title: string): void;
    openExternalLink(url: string): void;
    attachSideBarEvents(upButton: HTMLElement, scrollContentsArea: HTMLElement, downButton: HTMLElement): void;
}

export interface IMonacoInterop {
    initialize(editorElement: HTMLElement, initialValue: string, isReadOnly: boolean): void;
}

declare global {
    export module Interop {
        export const JS: IJSInterop;
        export const Monaco: IMonacoInterop;
    }
}

const jS: IJSInterop = new JSInterop();
const monaco: IMonacoInterop = new MonacoInterop();

(<any>global).Interop = {
    JS: {
        initializeWebView: (locale: string, title: string) : boolean => {
            jS.initializeWebView(locale, title);
            return true;
        },
        openExternalLink: (url: string) : boolean => {
            jS.openExternalLink(url);
            return true;
        },
        attachSideBarEvents: (upButton: HTMLElement, scrollContentsArea: HTMLElement, downButton: HTMLElement) : boolean => {
            jS.attachSideBarEvents(upButton, scrollContentsArea, downButton);
            return true;
        }
    },
    Monaco: {
        initialize: (editorElement: HTMLElement, initialValue: string, isReadOnly: boolean) : boolean => {
            monaco.initialize(editorElement, initialValue, isReadOnly);
            return true;
        }
    }
};
